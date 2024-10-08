namespace Abstractions;

public record DadosTabela
{
    public int Ano { get; set; }
    public decimal Valor { get; set; }
}

public record TabelaFinal
{
    public ICollection<DadosTabela> EnergiaGerada { get; set; } = [];
    public ICollection<DadosTabela> CustoImplantacao { get; set; } = [];
    public ICollection<DadosTabela> Manutencao { get; set; } = [];
}