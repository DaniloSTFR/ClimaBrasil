using System.Data;
using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Factoy;
using ClimaBrasil.Infrastructure.Queries.Input;
using Dapper;

namespace ClimaBrasil.Infrastructure.Repositories
{
    public class ErrorLogsRepository : IErrorLogsRepository
    {
        
        private readonly IDbConnection _dbConnection;

        public ErrorLogsRepository(SqlFactory factory)
        {
            _dbConnection = factory.SqlConnection();
        }
        public async Task<ErrorLogsEntity> AddErrorLogs(ErrorLogsEntity errorLogs)
        {

            if (errorLogs is null)
                throw new ArgumentNullException(nameof(errorLogs));

            var query = new InsertErrorLogsQuery().InsertErrorLogsQueryModel(errorLogs,true);
            try
            {
                using (_dbConnection)
                {
                    var errorLogsID = await _dbConnection.ExecuteScalarAsync(query.Query, query.Parameters);
                    if (errorLogsID is not null)
                    {
                        errorLogs.Id = Int32.Parse(errorLogsID.ToString());
                    }
                    else {
                        errorLogs.Id = 0;
                    }
                }   
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inserir Logs de Error.");
            }

            return errorLogs;
        }
    }
}