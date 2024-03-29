using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Factoy;
using ClimaBrasil.Infrastructure.Queries.Input;
using Dapper;
using System.Data;

namespace ClimaBrasil.Infrastructure.Repositories
{
    public class ClimaRepository : IClimaRepository
    {
        private readonly IDbConnection _dbConnection;

         public ClimaRepository(SqlFactory factory)
        {
            _dbConnection = factory.SqlConnection();
        }

        public void AddClima(List<ClimaEntity> climaList, int IdCidadeClima)
        {
            if (climaList is null && IdCidadeClima > 0)
                throw new ArgumentNullException(nameof(climaList));

            climaList.ForEach(x => { x.IdCidadeClima = IdCidadeClima;}); 

            var query = new InsertClimaQuery().InsertClimaQueryModel();

            try
            {
                using (_dbConnection)
                {
                    var climaID = _dbConnection.Execute(query.Query, climaList);
                }
            }
            catch(Exception e) 
            {
                throw new Exception("Erro ao inserir o Clima");
            }

        }

        public async void DeleteClimaByIdCidade(int IdCidadeClima)
        {
            if (IdCidadeClima <= 0)
                throw new ArgumentNullException(nameof(IdCidadeClima));

            var query = new DeleteClimaByIdCidadeClimaQuery().DeleteClimaByIdCidadeClimaQueryModel(IdCidadeClima);
            try
            {
                using (_dbConnection)
                {
                    await _dbConnection.ExecuteAsync(query.Query, query.Parameters);
                }   
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao excluir o Clima.");
            }
        }

    }
}