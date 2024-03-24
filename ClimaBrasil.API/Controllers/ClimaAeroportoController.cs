using System.Net;
using ClimaBrasil.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClimaBrasil.API.Controllers
{
    [ApiController]
    [Route("api/aeroporto/[controller]")]
    public class ClimaAeroportoController : ControllerBase
    {
        public readonly IAeroportoService _aeroportoService;

        public ClimaAeroportoController(IAeroportoService aeroportoService)
        {
            _aeroportoService = aeroportoService;
        }

        [HttpGet("clima/{codigoAeroporto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarAeroportoClima([FromRoute] string codigoAeroporto) 
        {
            var response = await _aeroportoService.BuscarAeroportoClima(codigoAeroporto);

            if(response.CodigoHttp == HttpStatusCode.OK) 
            {
                return Ok(response.DadosRetorno);
            }
            else 
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }
    }
}