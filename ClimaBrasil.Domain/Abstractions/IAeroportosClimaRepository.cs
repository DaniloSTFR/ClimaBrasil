using ClimaBrasil.Domain.Entities;

namespace ClimaBrasil.Domain.Abstractions
{
    public interface IAeroportosClimaRepository
    {
        Task<IEnumerable<AeroportoEntity>> GetClimaAeroporto();
        Task<AeroportoEntity> GetClimaAeroportoById(int id);
        Task<AeroportoEntity> AddClimaAeroporto(AeroportoEntity climaAeroporto);
        void UpdateClimaAeroporto(AeroportoEntity climaAeroporto);
        Task<AeroportoEntity> DeleteClimaAeroporto(int id);

        //TODO: GetClimaAeroportoByCodigoICAO
    }
}