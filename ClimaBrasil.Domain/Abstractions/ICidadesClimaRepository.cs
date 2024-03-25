using ClimaBrasil.Domain.Entities;


namespace ClimaBrasil.Domain.Abstractions
{
    public interface ICidadesClimaRepository
    {
        Task<IEnumerable<CidadeEntity>> GetClimaCidade();
        Task<CidadeEntity> GetClimaCidadeById(int id);
        Task<CidadeEntity> AddClimaCidade(CidadeEntity climaCidade);
        void UpdateClimaCidade(CidadeEntity climaCidade);
        Task<CidadeEntity> DeleteClimaCidade(int id);

        //TODO: GetClimaCidadeByCityCode
    }
}