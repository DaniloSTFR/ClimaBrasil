using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Output
{
    public class SelectAllAeroportoClimaQuery : BaseQuery
    {
        public QueryModel SelectAllAeroportoClimaQueryModel()
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
            ";

            return new QueryModel(this.Query);
        }
        


    }
}