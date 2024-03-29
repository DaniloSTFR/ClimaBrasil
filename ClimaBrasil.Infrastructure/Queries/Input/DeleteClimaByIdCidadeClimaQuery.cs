using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Input
{
    public class DeleteClimaByIdCidadeClimaQuery : BaseQuery
    {
        public QueryModel DeleteClimaByIdCidadeClimaQueryModel(int cidadeId)
        {
            this.Table = Map.GetClimaTable();

            this.Query = $@"
                DELETE FROM {this.Table}
                WHERE IdCidadeClima = @IdCidadeClima
            ";

            this.Parameters = new { IdCidadeClima = cidadeId };

            return new QueryModel(this.Query, this.Parameters); 
        }
    }
}