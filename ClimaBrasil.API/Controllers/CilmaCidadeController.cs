using System.Net;
using ClimaBrasil.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClimaBrasil.API.Controllers
{

    [ApiController]
    [Route("api/cidade/[controller]")]
    public class CilmaCidadeController : ControllerBase
    {
        public readonly ICidadeService _cidadeService;

        public CilmaCidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }


        [HttpGet("clima/{codigoCidade}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarCidadeClima([FromRoute] int codigoCidade) 
        {
            var response = await _cidadeService.BuscarCidadeClima(codigoCidade);

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