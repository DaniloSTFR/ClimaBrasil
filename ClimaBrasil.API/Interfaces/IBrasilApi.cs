using ClimaBrasil.API.DTOs;
using ClimaBrasil.API.Models;

namespace ClimaBrasil.Interfaces
{
    public interface IBrasilApi
    {
        Task<ResponseGenerico<CidadeModel>> BuscarCidadeClima(int cityCode);
        Task<ResponseGenerico<AeroportoModel>> BuscarAeroportoClima(string icaoCode);
    }
}