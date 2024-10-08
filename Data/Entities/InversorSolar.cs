using Data.Enumerators;

namespace Data.Entities;

public class InversorSolar : BaseEntity
{
    public string Modelo { get; set; }

    public int TensaoSaidaMin { get; set; }

    public int TensaoSaidaMax { get; set; }

    public int TensaoEntradaMax { get; set; }

    public decimal Potencia { get; set; }

    public TipoFase TipoFase { get; set; }
    public decimal Valor { get; set; }
}