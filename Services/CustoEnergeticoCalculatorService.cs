using Abstractions;
using Data;

namespace Services;

public class CustoEnergeticoCalculatorService(IAerogeradoresCalculoService aeroService, IBiodigestorCalculoService biodigestorService, IFotovoltaicoCalculoService fotovoltaicoService) : ICustoEnergeticoCalculatorService
{
    public async Task<Resposta> CalcularModeloBase(Problema problema, CancellationToken cancellationToken = default)
    {
        var aeroLcoe = await aeroService.CalcularLcoe(problema, cancellationToken);
        var fotoLcoe = await fotovoltaicoService.CalcularLcoe(problema, cancellationToken);
        var bioLcoe = await biodigestorService.CalcularLcoe(problema, cancellationToken);

        ICollection<(decimal, string)> list = [(aeroLcoe, "Eólico"), (fotoLcoe, "Fotovoltaico"), (bioLcoe, "Biodigestor")];
        var minimum = list.OrderBy(x => x.Item1).FirstOrDefault();
        return new Resposta
        {
            Melhor = minimum.Item2,
            Aerogerador = new RespostaConjunto
            {
                Tabela = aeroService.Tabela,
                //TabelaVpl = aeroService.TabelaVpl,
                Lcoe = aeroLcoe,
                CustoImplantacao = aeroService.CustoInstalacao,
                DadosExtra = new { aeroService.Aerogerador },
            },
            Fotovoltaico = new RespostaConjunto
            {
                Tabela = fotovoltaicoService.Tabela,
                //TabelaVpl = aeroService.TabelaVpl,
                Lcoe = fotoLcoe,
                CustoImplantacao = fotovoltaicoService.CustoInstalacao,
                DadosExtra = new
                {
                    fotovoltaicoService.PainelSolar,
                    fotovoltaicoService.InversorSolar,
                    fotovoltaicoService.Quantidade
                },
            },
            Biodigestor = new RespostaConjunto
            {
                Tabela = biodigestorService.Tabela,
                //TabelaVpl = aeroService.TabelaVpl,
                Lcoe = bioLcoe,
                CustoImplantacao = biodigestorService.CustoInstalacao,
                DadosExtra = new
                {
                    biodigestorService.NumeroMinimoAnimais,
                    problema.Animal
                }
            }
        };
    }
}