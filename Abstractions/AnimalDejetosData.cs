using Data.Enumerators;

namespace Abstractions;

public record AnimalDejetosData(
    TipoAnimal Animal,
    decimal FatorDejetosAgua,
    decimal DejetosLporDia,
    decimal BiogasMensal,
    int TRH);