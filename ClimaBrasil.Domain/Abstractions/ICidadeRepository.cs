using ClimaBrasil.Domain.Entities;


namespace ClimaBrasil.Domain.Abstractions
{
    public interface ICidadeRepository
    {
        Task<IEnumerable<CidadeEntity>> GetClimaCidade();
        Task<CidadeEntity> GetClimaCidadeById(int Id);
        Task<CidadeEntity> AddClimaCidade(CidadeEntity climaCidade);
        void UpdateClimaCidade(CidadeEntity climaCidade);
        Task<CidadeEntity> DeleteClimaCidade(int Id);

        //TODO: GetClimaCidadeByCityCode
    }
}