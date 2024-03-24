using ClimaBrasil.API.DTOs;

namespace ClimaBrasil.API.Interfaces
{
    public interface ICidadeService
    {
        Task<ResponseGenerico<CidadeResponse>> BuscarCidadeClima(int codigoCidade);
    }
}