using Data.Enumerators;

namespace Abstractions.Extensions;

public static class TipoAnimalExtension
{
    private static readonly ICollection<AnimalDejetosData> dados = [
        new(TipoAnimal.AVES, 0.33m, 0.18m, 0.42m, 60),
        new(TipoAnimal.CAPRINOS, 0.20m, 5m, 2.1m, 45),
        new(TipoAnimal.BOVINOS, 1m, 10m, 16.2m, 30),
        new(TipoAnimal.BOVINOS_L, 1m, 30m, 28.5m, 30),
        new(TipoAnimal.BEZERROS, 1m, 2m, 16.2m, 30),
        new(TipoAnimal.BOIS_CORTE, 1m, 15m, 16.2m, 30),
        new(TipoAnimal.EQUINOS, 1m, 10m, 10.8m, 45),
        new(TipoAnimal.SUINOS_M, 0.5m, 9m, 7.2m, 30),
        new(TipoAnimal.SUINOS_F, 0.5m, 27m, 7.2m, 30),
        new(TipoAnimal.LEITOES, 0.5m, 1.4m, 7.2m, 30),
    ];

    public static AnimalDejetosData GetFullInfo(this TipoAnimal animal) => dados.FirstOrDefault(x => x.Animal == animal);
}