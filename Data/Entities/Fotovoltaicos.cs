namespace Data.Entities;

public class Fotovoltaicos
{
    public InversorSolar InversorSolar { get; set; }
    public Guid InversorSolarId { get; set; }

    public PainelSolar PainelSolar { get; set; }
    public Guid PainelSolarId { get; set; }
}