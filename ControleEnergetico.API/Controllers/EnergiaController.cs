using Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ControleEnergetico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnergiaController(ILogger<EnergiaController> logger, ICustoEnergeticoCalculatorService custoService) : ControllerBase
    {
        private readonly ILogger<EnergiaController> _logger = logger;
        private readonly ICustoEnergeticoCalculatorService _custoService = custoService;

        [HttpPost]
        public async Task<IActionResult> GetResult(Problema req, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Received request: {Request}", req);
            var result = await _custoService.CalcularModeloBase(req, cancellationToken);

            return Ok(result);
        }
    }
}