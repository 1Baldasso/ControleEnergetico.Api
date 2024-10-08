namespace Abstractions;

public interface ICustoEnergeticoCalculatorService
{
    Task<Resposta> CalcularModeloBase(Problema problema, CancellationToken cancellationToken = default);
}