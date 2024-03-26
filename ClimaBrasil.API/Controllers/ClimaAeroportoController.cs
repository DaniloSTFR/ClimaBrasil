using System.Net;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ClimaBrasil.Application.Handlers.AeroportosClima.Queries;
using ClimaBrasil.Application.Handlers.AeroportosClima.Commands;
using ClimaBrasil.Application.Handlers.BrasilApiClima.Queries;

namespace ClimaBrasil.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClimaAeroportoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClimaAeroportoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("clima/fromAPI/{codigoAeroporto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarAeroportoClimaInApi([FromRoute] string codigoAeroporto) 
        {
            var query = new BuscarAeroportoClimaByIcaoCode{ CodigoAeroporto = codigoAeroporto };
            var response = await _mediator.Send(query);

            if(response.CodigoHttp == HttpStatusCode.OK) 
            {
                var command = new CreateAeroportoClimaCommand{ aeroportoResponse = response.DadosRetorno };
                var createdAeroportoClimaInDb = await _mediator.Send(command);

                return Ok(createdAeroportoClimaInDb);
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
        public async Task<IActionResult> BuscarAeroportosClimaInDataBase() 
        {
            var query = new GetAllAeroportosClimaQuery();
            var allAeroportoClimaInDb = await _mediator.Send(query);
            return Ok(allAeroportoClimaInDb);
        }

        [HttpGet("clima/InDb/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarAeroportoClimaInDataBase([FromRoute] int id)  
        {
            var query = new GetAeroportoClimaByIdQuery{ Id = id };
            var aeroportoClimaInDb = await _mediator.Send(query);
            return aeroportoClimaInDb != null ? Ok(aeroportoClimaInDb) : 
                NotFound("Clima do Aeroporto não encontrado no Banco de Dados.");
        }

        [HttpDelete("clima/InDb/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAeroportoClimaInDataBase([FromRoute] int id)  
        {
            var command = new DeleteAeroportoClimaCommand{ Id = id };
            var deleteAeroportoClimaInDb = await _mediator.Send(command);
            return deleteAeroportoClimaInDb != null ? Ok(deleteAeroportoClimaInDb) : 
                NotFound("Clima do Aeroporto não encontrado no Banco de Dados.");
        }
    }
}