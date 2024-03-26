using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Input
{
    public class InsertAeroportoClimaQuery : BaseQuery
    {
        public QueryModel InsertAeroportoClimaQueryModel(AeroportoEntity aeroporto, bool returnID)
        {
            string returnIDStr = "";
            if(returnID) returnIDStr = " OUTPUT inserted.Id AS Id ";

            this.Table = Map.GetAeroportoClimaTable(); 

            this.Query = $@"
            INSERT INTO {this.Table}
            {returnIDStr}
            VALUES
            (
                @CodigoAeroporto,
                @AtualizadoEm,
                @PressaoAtmosferica,
                @Visibilidade,
                @Vento,
                @DirecaoVento,
                @Umidade,
                @Condicao,
                @CondicaoDesc,
                @Temp,
                @RotaRequest,
                @CreatedOn
            )
            ";
            this.Parameters = new 
            {
                CodigoAeroporto = aeroporto.CodigoAeroporto,
                AtualizadoEm = aeroporto.AtualizadoEm,
                PressaoAtmosferica = aeroporto.PressaoAtmosferica,
                Visibilidade = aeroporto.Visibilidade,
                Vento = aeroporto.Vento,
                DirecaoVento = aeroporto.DirecaoVento,
                Umidade = aeroporto.Umidade,
                Condicao = aeroporto.Condicao,
                CondicaoDesc = aeroporto.CondicaoDesc,
                Temp = aeroporto.Temp,
                RotaRequest = aeroporto.RotaRequest,
                CreatedOn = aeroporto.CreatedOn
            };

            return new QueryModel(this.Query, this.Parameters);            

        }
        
    }
}