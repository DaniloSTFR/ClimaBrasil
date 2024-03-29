using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Output
{
    public class SelectCidadeClimaByIdQuery : BaseQuery
    {
        public QueryModel SelectCidadeClimaByIdQueryModel(int cidadeId)
        {       
            this.Query = $@"
                SELECT 
                    CC.[Id]
                    ,CC.[CodigoCidade]
                    ,CC.[Cidade]
                    ,CC.[Estado]
                    ,CC.[AtualizadoEm]
                    ,CC.[RotaRequest]
                    ,CC.[CreatedOn]
                FROM dbo.[CidadeClima] AS CC
                WHERE CC.Id = @Id 
            ";

            this.Parameters = new { Id = cidadeId };

            return new QueryModel(this.Query, this.Parameters); 
        }

        public QueryModel SelectClimaByIdCidadeQueryModel(int cidadeId)
        {       
            this.Query = $@"
                SELECT 
                    CL.[Id]
                    ,CL.[IdCidadeClima]
                    ,CL.[Data]
                    ,CL.[Condicao]
                    ,CL.[Min]
                    ,CL.[Max]
                    ,CL.[IndiceUv]
                    ,CL.[CondicaoDesc]
                    ,CL.[CreatedOn]
                FROM dbo.[CidadeClima] AS CC
                INNER JOIN [dbo].[Clima] AS CL ON CL.IdCidadeClima = CC.Id
                WHERE CC.Id = @Id 
            ";

            this.Parameters = new { Id = cidadeId };

            return new QueryModel(this.Query, this.Parameters); 
        }
    }
}