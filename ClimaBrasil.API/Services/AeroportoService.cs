using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClimaBrasil.API.DTOs;
using ClimaBrasil.API.Interfaces;
using ClimaBrasil.Interfaces;

namespace ClimaBrasil.API.Services
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