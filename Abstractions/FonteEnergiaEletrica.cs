namespace Abstractions;

public abstract class FonteEnergiaEletrica
{
    public decimal CustoInstalacao { get; protected set; } = 0m;
    public decimal CustoMensalPorKWH { get; protected set; } = 0m;
}