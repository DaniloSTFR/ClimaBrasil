using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Application.BrasilApiRest.Interfaces;
using MediatR;

namespace ClimaBrasil.Application.Handlers.BrasilApiClima.Queries
{
    public class BuscarCidadeClimaByCityCode : IRequest<ResponseGenerico<CidadeResponse>>
    {
        public int CodigoCidade { get; set; }

        public class BuscarCidadeClimaByCityCodeHandler : IRequestHandler<BuscarCidadeClimaByCityCode, ResponseGenerico<CidadeResponse>>
        {
            public readonly ICidadeService _cidadeService;

            public BuscarCidadeClimaByCityCodeHandler(ICidadeService cidadeService)
            {
                _cidadeService = cidadeService;
            }

            public async Task<ResponseGenerico<CidadeResponse>> Handle(BuscarCidadeClimaByCityCode request, CancellationToken cancellationToken)
            {
                var response = await _cidadeService.BuscarCidadeClima(request.CodigoCidade);
                return response;
            }
        }

    }
}