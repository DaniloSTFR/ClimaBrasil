using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimaBrasil.Domain.Entities
{
    public class ErrorLogsEntity : BaseEntity
    {
        #region  External Props
        public int StatusCode { get;private set; }
        public string ErrorMessage {get;private set;}
        public string RotaControllerRequest {get;private set;}

        #endregion
        
        public ErrorLogsEntity(int statusCode, string errorMessage, string rotaControllerRequest)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            RotaControllerRequest = rotaControllerRequest;
        }
    }
}