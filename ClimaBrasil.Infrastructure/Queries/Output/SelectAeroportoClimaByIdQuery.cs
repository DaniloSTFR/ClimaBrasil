using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Output
{
    public class SelectAeroportoClimaByIdQuery : BaseQuery
    {

        public QueryModel SelectAeroportoClimaByIdQueryModel(int aeroportoId)
        {
            this.Table = Map.GetAeroportoClimaTable(); 

            this.Query = $@"
                SELECT 
                    Id,
                    CodigoAeroporto,
                    AtualizadoEm,
                    PressaoAtmosferica,
                    Visibilidade,
                    Vento,
                    DirecaoVento,
                    Umidade,
                    Condicao,
                    CondicaoDesc,
                    Temp,
                    RotaRequest,
                    CreatedOn 
                FROM {this.Table}
                WHERE Id = @Id                    
            ";

            this.Parameters = new { Id = aeroportoId };

            return new QueryModel(this.Query, this.Parameters); 
        }
        
    }
}