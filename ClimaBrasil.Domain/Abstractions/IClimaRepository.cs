using ClimaBrasil.Domain.Entities;

namespace ClimaBrasil.Domain.Abstractions
{
    public interface IClimaRepository
    {
        void AddClima(List<ClimaEntity> climaList, int IdCidadeClima);
        
    }
}