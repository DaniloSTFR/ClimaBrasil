using AutoMapper;
using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Application.BrasilApiRest.Interfaces;

namespace ClimaBrasil.Application.BrasilApiRest.Services
{
    public class AeroportoService : IAeroportoService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public AeroportoService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseGenerico<AeroportoResponse>> BuscarAeroportoClima(string codigoAeroporto)
        {
            var aeroporto = await _brasilApi.BuscarAeroportoClima(codigoAeroporto);

            return _mapper.Map<ResponseGenerico<AeroportoResponse>>(aeroporto);
        }
    }
}