using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;


namespace ClimaBrasil.Infrastructure.Factoy
{
    public class SqlFactory
    {
         private readonly IConfiguration _configuration;

        public SqlFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection SqlConnection()
        {
            var connString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connString);
        }
    }
}