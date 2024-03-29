using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Factoy;
using ClimaBrasil.Infrastructure.Queries.Input;
using ClimaBrasil.Infrastructure.Queries.Output;
using Dapper;
using System.Data;

namespace ClimaBrasil.Infrastructure.Repositories
{
    public class AeroportosClimaRepository : IAeroportosClimaRepository
    {
        private readonly IDbConnection _dbConnection;

        public AeroportosClimaRepository(SqlFactory factory)
        {
            _dbConnection = factory.SqlConnection();
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
                    if (climaAeroportoID is not null)
                    {
                        climaAeroporto.Id = Int32.Parse(climaAeroportoID.ToString());
                    }
                    else {
                        climaAeroporto.Id = 0;
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao inserir Clima do Aeroporto.");
            }

            return climaAeroporto;
        }

        public async Task<AeroportoEntity> DeleteClimaAeroporto(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            var aeroporto = await GetClimaAeroportoById(id);

            if (aeroporto is not null)
            {
                var query = new DeleteAeroportoClimaByIdQuery().DeleteAeroportoClimaByIdQueryModel(id);
                try
                {
                    using (_dbConnection)
                    {
                    await _dbConnection.ExecuteAsync(query.Query, query.Parameters);
                    }   
                }
                catch
                {
                    throw new Exception("Erro ao excluir o Clima do Aeroporto.");
                }
            }
            return aeroporto;
        }

        public async Task<IEnumerable<AeroportoEntity>> GetClimaAeroporto()
        {
            var query = new SelectAllAeroportoClimaQuery().SelectAllAeroportoClimaQueryModel();
            return await _dbConnection.QueryAsync<AeroportoEntity>(query.Query);
        }

        public async Task<AeroportoEntity> GetClimaAeroportoById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            var query = new SelectAeroportoClimaByIdQuery().SelectAeroportoClimaByIdQueryModel(id);
            return await _dbConnection.QueryFirstOrDefaultAsync<AeroportoEntity>(query.Query, query.Parameters);
        }

        public void UpdateClimaAeroporto(AeroportoEntity climaAeroporto)
        {
            throw new NotImplementedException();
        }
    }
}