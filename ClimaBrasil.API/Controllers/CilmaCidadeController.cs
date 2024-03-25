using System.Net;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ClimaBrasil.Application.Handlers.BrasilApiClima.Queries;

namespace ClimaBrasil.API.Controllers
{

    [ApiController]
    [Route("api/cidade/[controller]")]
    public class CilmaCidadeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CilmaCidadeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("clima/fromAPI/{codigoCidade}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarCidadeClimaInApi([FromRoute] int codigoCidade) 
        {
            var query = new BuscarCidadeClimaByCityCode{ CodigoCidade = codigoCidade };
            var response = await _mediator.Send(query);

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