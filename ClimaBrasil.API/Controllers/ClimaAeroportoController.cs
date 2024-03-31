using System.Net;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ClimaBrasil.Application.Handlers.AeroportosClima.Queries;
using ClimaBrasil.Application.Handlers.AeroportosClima.Commands;
using ClimaBrasil.Application.Handlers.BrasilApiClima.Queries;
using ClimaBrasil.Application.Handlers.ErrorLogs.Commands;
using ClimaBrasil.Application.BrasilApiRest.Abstractions;
using System.Text.Json;

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
  
            try
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
                    var json = JsonSerializer.Serialize(response.ErroRetorno);
                    ErroRetornoAbstractions erroRetorno = JsonSerializer.Deserialize<ErroRetornoAbstractions>(json);
                    var error = new ErrorLogsCommand{StatusCode = (int)response.CodigoHttp, ErrorMessage = erroRetorno.message , RotaControllerRequest = $"ClimaAeroporto/clima/fromAPI/{codigoAeroporto}"};
                    var responseError = await _mediator.Send(error);

                    return StatusCode((int)response.CodigoHttp, responseError);
                }
                    
            }
            catch (Exception e)
            {
                var error = new ErrorLogsCommand{StatusCode = 500, ErrorMessage = e.Message, RotaControllerRequest = $"ClimaAeroporto/clima/fromAPI/{codigoAeroporto}"};
                var responseError = await _mediator.Send(error);

                return StatusCode(error.StatusCode, responseError);
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
            return aeroportoClimaInDb is not null ? Ok(aeroportoClimaInDb) : 
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
            return deleteAeroportoClimaInDb is not null ? Ok(deleteAeroportoClimaInDb) : 
                NotFound("Clima do Aeroporto não encontrado no Banco de Dados.");
        }
    }
}