using ClimaBrasil.API.DTOs;

namespace ClimaBrasil.API.Interfaces
{
    public interface IAeroportoService
    {
         Task<ResponseGenerico<AeroportoResponse>> BuscarAeroportoClima(string codigoAeroporto);
    }
}