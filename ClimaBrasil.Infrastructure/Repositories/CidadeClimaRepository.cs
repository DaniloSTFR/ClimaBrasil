

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

        public async Task<CidadeEntity> AddClimaCidade(CidadeEntity climaCidade)
        {
            ClimaRepository _climaRepository = new ClimaRepository(_dbConnection);

            if (climaCidade is null)
                throw new ArgumentNullException(nameof(climaCidade));

            var query = new InsertCidadeClimaQuery().InsertCidadeClimaQueryModel(climaCidade,true);
            try
            {
                using (_dbConnection)
                {
                   var climaCidadeID = await _dbConnection.ExecuteScalarAsync(query.Query, query.Parameters);
                    if (climaCidadeID != null)
                    {
                        climaCidade.Id = Int32.Parse(climaCidadeID.ToString());
                        _climaRepository.AddClima(climaCidade.Clima,climaCidade.Id);
                    }
                    else {
                        climaCidade.Id = 0;
                    }
                }   
            }
            catch
            {
                throw new Exception("Erro ao inserir Clima da Cidade");
            }

            return climaCidade;
        }

        public Task<CidadeEntity> DeleteClimaCidade(int id)
        {
            throw new NotImplementedException();
        }

        // TODO: Avaliar os retornos pois envolvem mais de uma tabela, usar Inner join
        //SELECT * FROM CidadeClima AS CC
	    //INNER JOIN Clima AS CL ON CC.Id = CL.[IdCidadeClima]
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