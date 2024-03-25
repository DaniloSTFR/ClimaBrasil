using ClimaBrasil.Application.BrasilApiRest.DTOs;

namespace ClimaBrasil.Application.BrasilApiRest.Interfaces
{
    public interface ICidadeService
    {
        Task<ResponseGenerico<CidadeResponse>> BuscarCidadeClima(int codigoCidade);
    }
}