using ClimaBrasil.Domain.Entities;
using ClimaBrasil.Infrastructure.Shared;

namespace ClimaBrasil.Infrastructure.Queries.Input
{
    public class InsertErrorLogsQuery : BaseQuery
    {
        public QueryModel InsertErrorLogsQueryModel(ErrorLogsEntity error, bool returnID)
        {

            string returnIDStr = "";
            if(returnID) returnIDStr = " OUTPUT inserted.Id AS Id ";

            this.Table = Map.GetErrorLogsTable();

            this.Query = $@"
                INSERT INTO {this.Table}
                {returnIDStr}
                VALUES
                (   
                    @StatusCode,
                    @ErrorMessage,
                    @RotaControllerRequest,
                    @CreatedOn
                )
            ";

            this.Parameters = new 
            {
                StatusCode = error.StatusCode,
                ErrorMessage = error.ErrorMessage,
                RotaControllerRequest = error.RotaControllerRequest,
                CreatedOn = error.CreatedOn
            };

            return new QueryModel(this.Query, this.Parameters);
        }
        
    }
}