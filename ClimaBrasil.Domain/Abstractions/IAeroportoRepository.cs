using ClimaBrasil.Domain.Entities;

namespace ClimaBrasil.Domain.Abstractions
{
    public interface IAeroportoRepository
    {
        Task<IEnumerable<AeroportoEntity>> GetClimaAeroporto();
        Task<AeroportoEntity> GetClimaAeroportoById(int Id);
        Task<AeroportoEntity> AddClimaAeroporto(AeroportoEntity climaAeroporto);
        void UpdateClimaAeroporto(AeroportoEntity climaAeroporto);
        Task<AeroportoEntity> DeleteClimaAeroporto(int Id);

        //TODO: GetClimaAeroportoByCodigoICAO
    }
}