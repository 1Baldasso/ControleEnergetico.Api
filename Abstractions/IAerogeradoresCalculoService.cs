using Data.Entities;

namespace Abstractions;

public interface IAerogeradoresCalculoService : IEspecificoCalculoService
{
    Aerogeradores Aerogerador { get; }
}