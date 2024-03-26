using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Input
{
    public class InsertCidadeClimaQuery : BaseQuery
    {
        public QueryModel InsertCidadeClimaQueryModel(CidadeEntity clima)
        {
            this.Table = Map.GetCidadeClimaTable();

            this.Query = $@"
            INSERT INTO {this.Table}
            VALUES
            (
                @Cidade,
                @Estado,
                @AtualizadoEm,
                @RotaRequest,
                @CreatedOn
            )
            ";

            this.Parameters = new 
            {
                Cidade = clima.Cidade,
                Estado = clima.Estado,
                AtualizadoEm = clima.AtualizadoEm,
                RotaRequest = clima.RotaRequest,
                CreatedOn = clima.CreatedOn
            };

            return new QueryModel(this.Query, this.Parameters);
        }
        
    }
}