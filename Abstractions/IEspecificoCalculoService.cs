namespace Abstractions;

public interface IEspecificoCalculoService
{
    Task<decimal> CalcularLcoe(Problema problema, CancellationToken cancellationToken = default);

    /// <summary>
    /// Populated just after <see cref="CalcularLcoe(Problema, CancellationToken)" is executed/>
    /// </summary>
    TabelaFinal Tabela { get; }

    //TabelaVpl TabelaVpl { get; }

    decimal CustoInstalacao { get; }
}