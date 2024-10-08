using Data.Entities;

namespace Abstractions;

public interface IFotovoltaicoCalculoService : IEspecificoCalculoService
{
    PainelSolar PainelSolar { get; }
    InversorSolar InversorSolar { get; }
    int Quantidade { get; }
}