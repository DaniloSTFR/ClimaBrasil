using ClimaBrasil.Application.BrasilApiRest.DTOs;

namespace ClimaBrasil.Application.BrasilApiRest.Interfaces
{
    public interface IAeroportoService
    {
         Task<ResponseGenerico<AeroportoResponse>> BuscarAeroportoClima(string codigoAeroporto);
    }
}