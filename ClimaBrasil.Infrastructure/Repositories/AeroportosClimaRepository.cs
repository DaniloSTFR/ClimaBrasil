using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using Dapper;
using System.Data;

namespace ClimaBrasil.Infrastructure.Repositories
{
    public class AeroportosClimaRepository : IAeroportosClimaRepository
    {
        private readonly IDbConnection _dbConnection;

        public AeroportosClimaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public Task<AeroportoEntity> AddClimaAeroporto(AeroportoEntity climaAeroporto)
        {
            throw new NotImplementedException();
        }

        public Task<AeroportoEntity> DeleteClimaAeroporto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AeroportoEntity>> GetClimaAeroporto()
        {
            string query = "SELECT * FROM dbo.AeroportoClima";
            return await _dbConnection.QueryAsync<AeroportoEntity>(query);
        }

        public async Task<AeroportoEntity> GetClimaAeroportoById(int id)
        {
            string query = "SELECT * FROM dbo.AeroportoClima WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<AeroportoEntity>(query, new { Id = id });
        }

        public void UpdateClimaAeroporto(AeroportoEntity climaAeroporto)
        {
            throw new NotImplementedException();
        }
    }
}