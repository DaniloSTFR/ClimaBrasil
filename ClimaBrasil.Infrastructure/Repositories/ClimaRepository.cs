using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Queries.Input;
using Dapper;
using System.Data;

namespace ClimaBrasil.Infrastructure.Repositories
{
    public class ClimaRepository : IClimaRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClimaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
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
    }
}