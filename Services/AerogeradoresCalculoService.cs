using Abstractions;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Services;

public class AerogeradoresCalculoService(EnergiaContext context) : IAerogeradoresCalculoService
{
    private TabelaFinal _tabela = new();
    public TabelaFinal Tabela => _tabela;

    public Aerogeradores Aerogerador => _aerogerador;
    public int Quantidade => _quantidade;

    private decimal _custoInstalacao = 0m;
    public decimal CustoInstalacao => _custoInstalacao;

    private TabelaVpl _tabelaVpl = new();
    public TabelaVpl TabelaVpl => _tabelaVpl;

    private Aerogeradores? _aerogerador = null;
    private int _quantidade = 1;

    public async Task<decimal> CalcularLcoe(Problema problema, CancellationToken cancellationToken = default)
    {
        var consumoMedioMensal = problema.Consumo;
        var incidencia = problema.ValoresAeroincidencia;
        var potenciaNecessaria = GetPotenciaNecessaria(consumoMedioMensal);
        var (aerogerador, valor, quantidade, energiaMensal) = await EncontrarMelhorModuloAsync(incidencia, consumoMedioMensal, problema.Aerogeradores, cancellationToken);
        _aerogerador = aerogerador;
        _quantidade = quantidade;

        var implantacao = ((aerogerador.CustoModeloInterno ?? 0) * quantidade * 100) / 70;
        _custoInstalacao = implantacao;
        var energiaPorMes = energiaMensal;
        var manutencao = implantacao * 0.02m;
        var manutencaoArr = new double[25];
        var energiaArr = new double[25];
        _tabelaVpl.Tabela.Add(new()
        {
            Periodo = 0,
            Custos = -implantacao,
            Receita = 0,
            Saldo = -implantacao,
            SaldoAcumulado = -implantacao,
            SaldoVPAcumulado = -implantacao,
            SaldoVP = -implantacao
        });
        for (int i = 0; i < 25; i++)
        {
            manutencaoArr[i] = decimal.ToDouble(manutencao);
            energiaArr[i] = decimal.ToDouble(energiaPorMes * 12);
            _tabela.Manutencao.Add(new DadosTabela
            {
                Ano = i + 1,
                Valor = manutencao
            });
            _tabela.EnergiaGerada.Add(new DadosTabela
            {
                Ano = i + 1,
                Valor = energiaPorMes * 12
            });
            _tabela.CustoImplantacao.Add(new DadosTabela
            {
                Ano = i + 1,
                Valor = 0
            });
            var saldoVp = energiaPorMes / (decimal)Math.Pow(1 + 0.1115, i + 1);
            var itemAnteriorTabela = _tabelaVpl.Tabela.ElementAt(i);
            _tabelaVpl.Tabela.Add(new()
            {
                Periodo = i + 1,
                Custos = 0,
                Receita = energiaPorMes,
                Saldo = energiaPorMes,
                SaldoVP = saldoVp,
                SaldoAcumulado = itemAnteriorTabela.SaldoAcumulado + energiaPorMes,
                SaldoVPAcumulado = itemAnteriorTabela.SaldoVPAcumulado + saldoVp,
            });
        }
        double manutencaoAno0 = Financial.NPV(0.1115, ref manutencaoArr);
        double energiaAno0 = Financial.NPV(0.1115, ref energiaArr);
        var lcoe = ((decimal)manutencaoAno0 + implantacao) / (decimal)energiaAno0;
        _tabela.CustoImplantacao.Add(new DadosTabela
        {
            Ano = 0,
            Valor = implantacao
        });
        _tabela.Manutencao.Add(new DadosTabela
        {
            Ano = 0,
            Valor = (decimal)manutencaoAno0,
        });
        _tabela.EnergiaGerada.Add(new DadosTabela
        {
            Ano = 0,
            Valor = (decimal)energiaAno0
        });
        _tabela.CustoImplantacao = [.. _tabela.CustoImplantacao.OrderBy(x => x.Ano)];
        _tabela.Manutencao = [.. _tabela.Manutencao.OrderBy(x => x.Ano)];
        _tabela.EnergiaGerada = [.. _tabela.EnergiaGerada.OrderBy(x => x.Ano)];
        _tabelaVpl.VPL = (decimal)(energiaAno0 - manutencaoAno0 - (double)implantacao);

        return lcoe;
    }

    private static decimal Weibull(decimal ak, decimal ac, decimal av)
    {
        var (k, c, v) = ((double)ak, (double)ac, (double)av);
        return (decimal)((k / c) * Math.Pow(v / c, k - 1) * Math.Exp(-Math.Pow(v / c, k)));
    }

    private static decimal GetPotenciaNecessaria(decimal energiaMes)
    {
        return energiaMes switch
        {
            > 0 and < 190 => 0.5m,
            >= 190 and < 240 => 1m,
            >= 240 and < 460 => 2m,
            >= 460 and < 570 => 3m,
            >= 570 and < 870 => 5m,
            >= 870 and < 1800 => 10m,
            >= 1800 and < 4950 => 20m,
            >= 4950 and < 5970 => 30m,
            >= 5970 and < 9290 => 50m,
            >= 9290 and < 24850 => 100m,
            _ => throw new NotImplementedException()
        };
    }

    private async Task<(Aerogeradores painel, decimal valor, int numero, decimal energiaMensal)> EncontrarMelhorModuloAsync(ValoresAeroincidencia valoresAeroincidencia, decimal energiaNecessaria, IEnumerable<Aerogeradores> paineisExtras, CancellationToken cancellationToken)
    {
        var paineis = await context.Aerogeradores
            .Include(x => x.Potenciais)
            .OrderBy(x => x.Potencia)
            .ToListAsync(cancellationToken);
        paineis.AddRange(paineisExtras);
        var dic = new Dictionary<Aerogeradores, (decimal, int, decimal)>();

        foreach (var painel in paineis)
        {
            for (int k = 1; ; k++)
            {
                var weibullTotal = 0m;
                var potenciaMediaTotal = 0m;
                for (int i = 0; i <= 20; i++)
                {
                    var potencia = painel.Potenciais.FirstOrDefault(x => x.Valor == i).Potencia * k;
                    var weibull = Weibull(valoresAeroincidencia.K, valoresAeroincidencia.C, i);
                    weibullTotal += weibull;
                    var potenciaMedia = potencia * weibull;
                    potenciaMediaTotal += potenciaMedia;
                }
                var energiaMensal = (potenciaMediaTotal / 1000) * 24 * 30;
                if (energiaMensal >= energiaNecessaria)
                {
                    dic.Add(painel, (painel.CustoModelo * k, k, energiaMensal));
                    break;
                }
            }
        }

        var result = dic.MinBy(x => x.Value.Item1);
        return (result.Key, result.Value.Item1, result.Value.Item2, result.Value.Item3);
    }
}