using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Input
{
    public class DeleteAeroportoClimaByIdQuery : BaseQuery
    {
        public QueryModel DeleteAeroportoClimaByIdQueryModel(int aeroportoId)
        {
            this.Table = Map.GetAeroportoClimaTable();

            this.Query = $@"
                DELETE FROM {this.Table}
                WHERE Id = @Id
            ";

            this.Parameters = new { Id = aeroportoId };

            return new QueryModel(this.Query, this.Parameters); 
        }
        
    }
}