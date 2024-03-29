using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Input
{
    public class InsertCidadeClimaQuery : BaseQuery
    {
        public QueryModel InsertCidadeClimaQueryModel(CidadeEntity cidade, bool returnID)
        {

            string returnIDStr = "";
            if(returnID) returnIDStr = " OUTPUT inserted.Id AS Id ";

            this.Table = Map.GetCidadeClimaTable();

            this.Query = $@"
                INSERT INTO {this.Table}
                {returnIDStr}
                VALUES
                (   
                    @CodigoCidade,
                    @Cidade,
                    @Estado,
                    @AtualizadoEm,
                    @RotaRequest,
                    @CreatedOn
                )
            ";

            this.Parameters = new 
            {
                CodigoCidade = cidade.CodigoCidade,
                Cidade = cidade.Cidade,
                Estado = cidade.Estado,
                AtualizadoEm = cidade.AtualizadoEm,
                RotaRequest = cidade.RotaRequest,
                CreatedOn = cidade.CreatedOn
            };

            return new QueryModel(this.Query, this.Parameters);
        }
        
    }
}