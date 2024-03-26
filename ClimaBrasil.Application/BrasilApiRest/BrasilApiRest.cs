using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Application.BrasilApiRest.Models;
using ClimaBrasil.Application.BrasilApiRest.Interfaces;
using System.Text.Json;
using System.Dynamic;

namespace ClimaBrasil.Application.BrasilApiRest
{
    public class BrasilApiRest : IBrasilApi
    {
        public async Task<ResponseGenerico<AeroportoModel>> BuscarAeroportoClima(string icaoCode)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cptec/v1/clima/aeroporto/{icaoCode}");

            var response = new ResponseGenerico<AeroportoModel>();
            using (var client = new HttpClient()) {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<AeroportoModel>(contentResp);

                if(objResponse != null) 
                    objResponse.RotaRequest = $"https://brasilapi.com.br/api/cptec/v1/clima/aeroporto/{icaoCode}";

                if (responseBrasilApi.IsSuccessStatusCode) 
                {    
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else 
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }

        public async Task<ResponseGenerico<CidadeModel>> BuscarCidadeClima(int cityCode)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cptec/v1/clima/previsao/{cityCode}");

            var response = new ResponseGenerico<CidadeModel>();
            using (var client = new HttpClient()) {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<CidadeModel>(contentResp);

                if(objResponse != null) 
                    objResponse.RotaRequest = $"https://brasilapi.com.br/api/cptec/v1/clima/previsao/{cityCode}"; 

                if (responseBrasilApi.IsSuccessStatusCode) 
                {    
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else 
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }
    }
}