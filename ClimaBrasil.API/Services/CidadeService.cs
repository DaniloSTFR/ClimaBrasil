

using AutoMapper;
using ClimaBrasil.API.DTOs;
using ClimaBrasil.API.Interfaces;
using ClimaBrasil.Interfaces;

namespace ClimaBrasil.API.Services 
{
    public class CidadeService : ICidadeService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public CidadeService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseGenerico<CidadeResponse>> BuscarCidadeClima(int codigoCidade)
        {
            var cidade = await _brasilApi.BuscarCidadeClima(codigoCidade);

            return _mapper.Map<ResponseGenerico<CidadeResponse>>(cidade);
        }
    }
}