using System.Text.Json.Serialization;

namespace ClimaBrasil.Application.BrasilApiRest.Models
{
    public class CidadeModel
    {
            
        [JsonPropertyName("cidade")]
        public string? Cidade { get; set; }

        [JsonPropertyName("estado")]
        public string? Estado { get; set; }

        [JsonPropertyName("atualizado_em")]
        public string? AtualizadoEm { get; set; }

        [JsonPropertyName("clima")]
        public List<ClimaModel>? Clima { get; set; }
    
    }
}