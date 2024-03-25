
namespace ClimaBrasil.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        ICidadeRepository CidadeRepository { get; }

        IAeroportoRepository AeroportoRepository { get; }
        Task CommitAsync();
    }
}
