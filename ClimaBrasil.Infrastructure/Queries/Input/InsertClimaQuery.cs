using ClimaBrasil.Infrastructure.Shared;
using ClimaBrasil.Domain.Entities;

namespace ClimaBrasil.Infrastructure.Queries.Input
{
    public class InsertClimaQuery : BaseQuery
    {
        public QueryModel InsertClimaQueryModel()
        {
            this.Table = Map.GetClimaTable();

            this.Query = $@"
                INSERT INTO {this.Table}
                        (IdCidadeClima
                            ,Data
                            ,Condicao
                            ,Min
                            ,Max
                            ,IndiceUv
                            ,CondicaoDesc
                            ,CreatedOn)
                VALUES
                (
                    @IdCidadeClima,
                    @Data,
                    @Condicao,
                    @Min,
                    @Max,
                    @IndiceUv,
                    @CondicaoDesc,
                    @CreatedOn
                )
            ";

            return new QueryModel(this.Query);
        }
    }
}