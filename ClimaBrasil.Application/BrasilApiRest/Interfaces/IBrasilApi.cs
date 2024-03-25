using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Application.BrasilApiRest.Models;

namespace ClimaBrasil.Application.BrasilApiRest.Interfaces
{
    public interface IBrasilApi
    {
        Task<ResponseGenerico<CidadeModel>> BuscarCidadeClima(int cityCode);
        Task<ResponseGenerico<AeroportoModel>> BuscarAeroportoClima(string icaoCode);
    }
}