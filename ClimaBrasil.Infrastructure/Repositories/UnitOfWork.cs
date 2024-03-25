
using ClimaBrasil.Domain.Abstractions;
//using ClimaBrasil.Infrastructure.Context;

namespace ClimaBrasil.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public ICidadesClimaRepository CidadeClimaRepository => throw new NotImplementedException();

        public IAeroportosClimaRepository AeroportoClimaRepository => throw new NotImplementedException();

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}