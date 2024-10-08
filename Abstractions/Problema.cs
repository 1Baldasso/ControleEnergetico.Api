using Data.Entities;
using Data.Enumerators;

namespace Abstractions;

public sealed record Problema
{
    public decimal? Custokwh { get; set; }
    public decimal Consumo { get; set; }
    public ICollection<decimal> IncidenciaSolar { get; set; }
    public TipoFase TipoFase { get; set; }
    public TipoAnimal Animal { get; set; }
    public ValoresAeroincidencia ValoresAeroincidencia { get; set; }
    public ICollection<Aerogeradores> Aerogeradores { get; set; } = [];
    public ICollection<PainelSolar> PaineisSolares { get; set; } = [];
    public ICollection<InversorSolar> InversoresSolares { get; set; } = [];
}