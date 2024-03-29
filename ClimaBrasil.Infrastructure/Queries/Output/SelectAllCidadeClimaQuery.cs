using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Output
{
    public class SelectAllCidadeClimaQuery : BaseQuery
    {
        public QueryModel SelectAllCidadeClimaQueryModel()
        {
            this.Table = Map.GetCidadeClimaTable();

            this.Query = $@"
                SELECT [Id]
                    ,[CodigoCidade]
                    ,[Cidade]
                    ,[Estado]
                    ,[AtualizadoEm]
                    ,[RotaRequest]
                    ,[CreatedOn]
                FROM {this.Table}
            ";
            return new QueryModel(this.Query);
        }
        
    }
}