namespace Abstractions;

public sealed record Resposta
{
    public string Melhor { get; set; }
    public RespostaConjunto Fotovoltaico { get; set; }
    public RespostaConjunto Aerogerador { get; set; }
    public RespostaConjunto Biodigestor { get; set; }
}

public sealed record RespostaConjunto
{
    public TabelaFinal Tabela { get; set; }
    public decimal Lcoe { get; set; }
    public decimal CustoImplantacao { get; set; }
    public object DadosExtra { get; set; }
    public TabelaVpl? TabelaVpl { get; set; }
}