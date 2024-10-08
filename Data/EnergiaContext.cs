using Data.Conversors;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class EnergiaContext : DbContext
{
    public EnergiaContext(DbContextOptions<EnergiaContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>()
            .AreUnicode(false);
        configurationBuilder.Properties<decimal>()
            .HaveConversion<LongConversor>();
    }

    public DbSet<Aerogeradores> Aerogeradores { get; set; }
    public DbSet<PainelSolar> PaineisSolares { get; set; }
    public DbSet<InversorSolar> InversoresSolares { get; set; }
}