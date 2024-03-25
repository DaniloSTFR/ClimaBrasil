using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Application.BrasilApiRest.Interfaces;
using MediatR;

namespace ClimaBrasil.Application.Handlers.BrasilApiClima.Queries
{
    public class BuscarAeroportoClimaByIcaoCode : IRequest<ResponseGenerico<AeroportoResponse>>
    {
        public string CodigoAeroporto { get; set; }

        public class BuscarAeroportoClimaByIcaoCodeHandler : IRequestHandler<BuscarAeroportoClimaByIcaoCode, ResponseGenerico<AeroportoResponse>>
        {

            public readonly IAeroportoService _aeroportoService;

            public BuscarAeroportoClimaByIcaoCodeHandler(IAeroportoService aeroportoService)
            {
                _aeroportoService = aeroportoService;
            }

            public async Task<ResponseGenerico<AeroportoResponse>> Handle(BuscarAeroportoClimaByIcaoCode request, CancellationToken cancellationToken)
            {
                var response = await _aeroportoService.BuscarAeroportoClima(request.CodigoAeroporto);
                return response;
            }
        }

    }
}