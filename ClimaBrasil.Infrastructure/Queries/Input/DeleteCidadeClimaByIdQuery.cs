using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Input
{
    public class DeleteCidadeClimaByIdQuery : BaseQuery
    {
        public QueryModel DeleteCidadeClimaByIdQueryModel(int cidadeId)
        {
            this.Table = Map.GetCidadeClimaTable();

            this.Query = $@"
                DELETE FROM [dbo].[Clima]
                WHERE IdCidadeClima = @IdCidadeClima;

                DELETE FROM {this.Table}
                WHERE Id = @Id;
            ";

            this.Parameters = new { Id = cidadeId, IdCidadeClima =  cidadeId};

            return new QueryModel(this.Query, this.Parameters); 
        }
    }
}