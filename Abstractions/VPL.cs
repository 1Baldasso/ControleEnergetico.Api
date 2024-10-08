namespace Abstractions;

public class VPL
{
    public int Periodo { get; set; }
    public decimal Custos { get; set; }
    public decimal Receita { get; set; }
    public decimal Saldo { get; set; }
    public decimal SaldoVP { get; set; }
    public decimal SaldoAcumulado { get; set; }
    public decimal SaldoVPAcumulado { get; set; }
}

public class TabelaVpl
{
    public decimal VPL { get; set; }
    public ICollection<VPL> Tabela { get; set; } = [];
    public int PaybackSimples => Tabela.FirstOrDefault(x => x.SaldoAcumulado > 0)?.Periodo - 1 ?? -1;
    public int PaybackDescontado => Tabela.FirstOrDefault(x => x.SaldoVPAcumulado > 0)?.Periodo - 1 ?? -1;
}