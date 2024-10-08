namespace Abstractions;

public interface IBiodigestorCalculoService : IEspecificoCalculoService
{
    int NumeroMinimoAnimais { get; }
}