using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Queries.Input;
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
        public async Task<AeroportoEntity> AddClimaAeroporto(AeroportoEntity climaAeroporto)
        {
            if (climaAeroporto is null)
                throw new ArgumentNullException(nameof(climaAeroporto));

            var query = new InsertAeroportoClimaQuery().InsertAeroportoClimaQueryModel(climaAeroporto,true);
            try
            {
                using (_dbConnection)
                {
                   var climaAeroportoID = await _dbConnection.ExecuteScalarAsync(query.Query, query.Parameters);
                    if (climaAeroportoID != null)
                    {
                        climaAeroporto.Id = Int32.Parse(climaAeroportoID.ToString());
                    }
                    else {
                        climaAeroporto.Id = 0;
                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao inserir Clima do Aeroporto");
            }

            return climaAeroporto;
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