

using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Queries.Input;
using Dapper;
using System.Data;

namespace ClimaBrasil.Infrastructure.Repositories
{
    public class CidadesClimaRepository : ICidadesClimaRepository
    {
        private readonly IDbConnection _dbConnection;

        public CidadesClimaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public Task<CidadeEntity> AddClimaCidade(CidadeEntity climaCidade)
        {
            if (climaCidade is null)
                throw new ArgumentNullException(nameof(climaCidade));

            var query = new InsertCidadeClimaQuery().InsertCidadeClimaQueryModel(climaCidade);
            try
            {
                using (_dbConnection)
                {
                   _dbConnection.Execute(query.Query, query.Parameters);
                }
            }
            catch
            {
                throw new Exception("Erro ao inserir veiculo");
            }

            return Task.FromResult(climaCidade);
        }

        public Task<CidadeEntity> DeleteClimaCidade(int id)
        {
            throw new NotImplementedException();
        }

        // TODO: Avaliar os retornos pois envolvem mais de uma tabela, usar Inner join
        //SELECT * FROM CidadeClima AS CC
	    //INNER JOIN Clima AS CL ON CC.Id = CL.[IdCidade]
        public async Task<IEnumerable<CidadeEntity>> GetClimaCidade()
        {
            string query = "SELECT * FROM dbo.CidadeClima";
            return await _dbConnection.QueryAsync<CidadeEntity>(query);
        }

        // TODO: Avaliar os retornos pois envolvem mais de uma tabela, usar Inner join
        public async Task<CidadeEntity> GetClimaCidadeById(int id)
        {
            string query = "SELECT * FROM dbo.CidadeClima WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<CidadeEntity>(query, new { Id = id });
        }

        public void UpdateClimaCidade(CidadeEntity climaCidade)
        {
            throw new NotImplementedException();
        }
    }
}