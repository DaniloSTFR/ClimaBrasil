
namespace ClimaBrasil.Domain.Abstractions
{
    //TODO: RETIRAR O IUnitOfWork
    public interface IUnitOfWork
    {
        ICidadesClimaRepository CidadeClimaRepository { get; }

        IAeroportosClimaRepository AeroportoClimaRepository { get; }
        Task CommitAsync();
    }
}
