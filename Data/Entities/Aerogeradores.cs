namespace Data.Entities;

public class Aerogeradores : BaseEntity
{
    public string Modelo { get; set; }
    public decimal Potencia { get; set; }
    public ICollection<PotenciaPorValor> Potenciais { get; set; }

    public decimal? CustoModeloInterno { get; set; }
    public decimal CustoModelo => CustoModeloInterno ?? 0 + Potencia * 1971.83m;
}