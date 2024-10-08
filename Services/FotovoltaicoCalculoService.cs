using Abstractions;
using Data;
using Data.Entities;
using Data.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Services;

public class FotovoltaicoCalculoService(EnergiaContext context) : IFotovoltaicoCalculoService
{
    private TabelaFinal _tabela = new();
    private InversorSolar? _inversor = null;
    private PainelSolar? _painel = null;
    private int _quantidade = 0;

    private const decimal TAXA_DESEMPENHO = 70;
    public TabelaFinal Tabela => _tabela;

    public PainelSolar PainelSolar => _painel;

    public InversorSolar InversorSolar => _inversor;

    public int Quantidade => _quantidade;

    private decimal _custoInstalacao = 0;

    public decimal CustoInstalacao => _custoInstalacao;
    private TabelaVpl _tabelaVpl = new();
    public TabelaVpl TabelaVpl => _tabelaVpl;

    public async Task<decimal> CalcularLcoe(Problema problema, CancellationToken cancellationToken = default)
    {
        var consumoMedioMensal = problema.Consumo;
        var incidenciaMediaMensal = problema.IncidenciaSolar.Average();
        var mediaCalculada = consumoMedioMensal - problema.TipoFase switch
        {
            TipoFase.MONOFASICO => 30,
            TipoFase.BIFASICO => 50,
            TipoFase.TRIFASICO => 100
        };

        var pfv = ((mediaCalculada / 30) / (TAXA_DESEMPENHO / 100)) / incidenciaMediaMensal;
        var inversores = await context.InversoresSolares.OrderBy(x => x.Potencia)
            .ToListAsync(cancellationToken);
        inversores.AddRange(problema.InversoresSolares);
        var inversor = inversores
            .FirstOrDefault(x => pfv - x.Potencia < 1);
        _inversor = inversor;
        var fdi = inversor.Potencia / pfv;

        var (painel, valor, quantidade) = await EncontrarMelhorModuloAsync(incidenciaMediaMensal, mediaCalculada, problema.PaineisSolares, cancellationToken);
        _painel = painel;
        _quantidade = quantidade;
        var energiaPorMes = (quantidade * painel.Potencia * 30.42m * incidenciaMediaMensal * (TAXA_DESEMPENHO / 100)) / 1000;
        var implantacao = valor + inversor.Valor;
        implantacao += implantacao * 0.04m;
        implantacao += implantacao * 0.22m;
        implantacao += implantacao * 0.3m;
        _custoInstalacao = implantacao;
        var manutencao = implantacao * 0.0093m;
        var manutencaoArr = new double[25];
        var energiaArr = new double[25];
        var implantacaoArr = new double[25];
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
            var implantacaoDaTabela = (i + 1) % 10 == 0 ? inversor.Valor : 0m;
            implantacaoArr[i] = decimal.ToDouble(implantacaoDaTabela);
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
                Valor = implantacaoDaTabela
            });
            var saldoVp = (decimal)(energiaArr[i] / Math.Pow(1 + 0.1115, i + 1));
            var itemAnteriorTabela = _tabelaVpl.Tabela.ElementAt(i);
            _tabelaVpl.Tabela.Add(new()
            {
                Periodo = i + 1,
                Custos = implantacaoDaTabela,
                Receita = energiaPorMes,
                Saldo = energiaPorMes,
                SaldoVP = saldoVp,
                SaldoAcumulado = itemAnteriorTabela.SaldoAcumulado + energiaPorMes,
                SaldoVPAcumulado = itemAnteriorTabela.SaldoVPAcumulado + saldoVp,
            });
        }
        implantacaoArr = implantacaoArr.Where(x => x != 0).ToArray();
        double manutencaoAno0 = Financial.NPV(0.1115, ref manutencaoArr);
        double energiaAno0 = Financial.NPV(0.1115, ref energiaArr);
        double implantacaoAno0 = decimal.ToDouble(implantacao) + Financial.NPV(0.1115, ref implantacaoArr);
        var lcoe = (decimal)(manutencaoAno0 + implantacaoAno0) / (decimal)energiaAno0;
        _tabela.CustoImplantacao.Add(new DadosTabela
        {
            Ano = 0,
            Valor = (decimal)implantacaoAno0
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

        return lcoe;
    }

    private async Task<(PainelSolar painel, decimal valor, int numero)> EncontrarMelhorModuloAsync(decimal mediaIrradiacao, decimal mediaCalculada, IEnumerable<PainelSolar> paineisExtras, CancellationToken cancellationToken)
    {
        var paineis = await context.PaineisSolares
            .OrderBy(x => x.Potencia)
            .ToListAsync(cancellationToken);
        paineis.AddRange(paineisExtras);
        var dic = new Dictionary<PainelSolar, (decimal, int)>();

        foreach (var painel in paineis)
        {
            for (int i = 5; ; i++)
            {
                if ((i * painel.Potencia * 30.42m * mediaIrradiacao * (TAXA_DESEMPENHO / 100)) / 1000 > mediaCalculada)
                {
                    dic.Add(painel, (painel.Valor * i, i));
                    break;
                }
            }
        }

        var result = dic.MinBy(x => x.Value.Item1);
        return (result.Key, result.Value.Item1, result.Value.Item2);
    }
}