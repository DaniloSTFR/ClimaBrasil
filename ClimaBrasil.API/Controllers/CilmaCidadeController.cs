using System.Net;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ClimaBrasil.Application.Handlers.BrasilApiClima.Queries;
using ClimaBrasil.Application.Handlers.CidadesClima.Queries;
using ClimaBrasil.Application.Handlers.CidadesClima.Commands;

namespace ClimaBrasil.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
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
                var command = new CreateCidadeClimaCommand{ cidadeResponse = response.DadosRetorno };
                var createdCiadeClimaInDb = await _mediator.Send(command);
                
                return Ok(response.DadosRetorno);
            }
            else 
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }

        [HttpGet("clima/InDb")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarCidadesClimaInDataBase() 
        {
            var query = new GetAllCidadesClimaQuery();
            var allCidadesClimaInDb = await _mediator.Send(query);
            return Ok(allCidadesClimaInDb);
        }

        [HttpGet("clima/InDb/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarCidadeClimaInDataBase([FromRoute] int id)  
        {
            var query = new GetCidadeClimaByIdQuery{ Id = id };
            var cidadeClimaInDb = await _mediator.Send(query);
            return cidadeClimaInDb != null ? Ok(cidadeClimaInDb) : 
                NotFound("Clima da Cidade não encontrado no Banco de Dados.");
        }

        [HttpDelete("clima/InDb/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCidadeClimaInDataBase([FromRoute] int id)  
        {
            var command = new DeleteCidadeClimaCommand{ Id = id };
            var deleteCidadeClimaInDb = await _mediator.Send(command);
            return deleteCidadeClimaInDb != null ? Ok(deleteCidadeClimaInDb) : 
                NotFound("Clima da Cidade não encontrado no Banco de Dados.");
        }




    }

}