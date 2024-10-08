using Abstractions;
using Abstractions.Extensions;
using Microsoft.VisualBasic;

namespace Services;

public class BiodigestorCalculoService : IBiodigestorCalculoService
{
    private readonly TabelaFinal _tabela = new();
    public TabelaFinal Tabela => _tabela;

    private int _numeroMinimoAnimais = 0;
    public int NumeroMinimoAnimais => _numeroMinimoAnimais;

    private decimal _custoInstalacao = decimal.Zero;
    public decimal CustoInstalacao => _custoInstalacao;
    private TabelaVpl _tabelaVpl = new();
    public TabelaVpl TabelaVpl => _tabelaVpl;

    public Task<decimal> CalcularLcoe(Problema problema, CancellationToken cancellationToken = default)
    {
        var consumoMedioMensal = problema.Consumo;
        var dados = problema.Animal.GetFullInfo();
        var needed = Math.Ceiling((consumoMedioMensal / 1.42m) / dados.BiogasMensal);
        _numeroMinimoAnimais = (int)needed;
        var trueGenerated = needed * dados.BiogasMensal * 1.42m;
        var vd = needed * dados.DejetosLporDia;
        var va = vd * dados.FatorDejetosAgua;
        var vc = vd + va;
        var volumeFossa = vc * dados.TRH / 1000;
        var custoBiodigestor = volumeFossa * (volumeFossa switch
        {
            > 0 and < 100 => 2695.93m,
            >= 100 and < 501 => 779.48m,
            >= 501 and < 3_001 => 292.11m,
            >= 3_001 and < 6_001 => 203.75m,
            >= 6_001 and < 20_000 => 168.69m,
            >= 20_000 and < 200_000 => 138.45m,
            >= 200_000 => 124.82m,
            _ => throw new NotImplementedException()
        });
        var custoMotor = (trueGenerated / 30) * 0.8m * 1600m;
        var investimentoTotal = custoBiodigestor + custoMotor;
        _custoInstalacao = investimentoTotal;
        var energiaArr = new double[25];
        var manutencaoArr = new double[25];
        _tabelaVpl.Tabela.Add(new()
        {
            Periodo = 0,
            Custos = -investimentoTotal,
            Receita = 0,
            Saldo = -investimentoTotal,
            SaldoAcumulado = -investimentoTotal,
            SaldoVPAcumulado = -investimentoTotal,
            SaldoVP = -investimentoTotal
        });
        for (var i = 0; i < 25; i++)
        {
            energiaArr[i] = (double)trueGenerated * 12;
            manutencaoArr[i] = (double)investimentoTotal * 0.1108;
            _tabela.Manutencao.Add(new DadosTabela
            {
                Ano = i + 1,
                Valor = (decimal)manutencaoArr[i]
            });
            _tabela.EnergiaGerada.Add(new DadosTabela
            {
                Ano = i + 1,
                Valor = (decimal)energiaArr[i]
            });
            _tabela.CustoImplantacao.Add(new DadosTabela
            {
                Ano = i + 1,
                Valor = 0
            });
            var saldoVp = (decimal)(energiaArr[i] / Math.Pow(1 + 0.1115, i + 1));
            var energiaPorMes = (decimal)energiaArr[i];
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
        var npvEnergia = Financial.NPV(0.1115, ref energiaArr);
        var npvManutencao = Financial.NPV(0.1115, ref manutencaoArr);
        _tabela.CustoImplantacao.Add(new DadosTabela
        {
            Ano = 0,
            Valor = investimentoTotal
        });
        _tabela.EnergiaGerada.Add(new DadosTabela
        {
            Ano = 0,
            Valor = (decimal)npvEnergia
        });
        _tabela.Manutencao.Add(new DadosTabela
        {
            Ano = 0,
            Valor = (decimal)npvManutencao
        });

        _tabela.CustoImplantacao = [.. _tabela.CustoImplantacao.OrderBy(x => x.Ano)];
        _tabela.Manutencao = [.. _tabela.Manutencao.OrderBy(x => x.Ano)];
        _tabela.EnergiaGerada = [.. _tabela.EnergiaGerada.OrderBy(x => x.Ano)];
        var lcoe = ((decimal)npvManutencao + investimentoTotal) / (decimal)npvEnergia;
        return Task.FromResult(lcoe);
    }
}