using System.Text.Json.Serialization;

namespace ClimaBrasil.API.Models
{
    public class AeroportoModel
    {
        [JsonPropertyName("codigo_icao")]
        public string? CodigoAeroporto { get; set; }

        [JsonPropertyName("atualizado_em")]
        public string? AtualizadoEm { get; set; }

        [JsonPropertyName("pressao_atmosferica")]
        public int? PressaoAtmosferica { get; set; }

        [JsonPropertyName("visibilidade")]
        public string? Visibilidade { get; set; }

        [JsonPropertyName("vento")]
        public int? Vento { get; set; }

        [JsonPropertyName("direcao_vento")]
        public int? DirecaoVento { get; set; }

        [JsonPropertyName("umidade")]
        public int? Umidade { get; set; }

        [JsonPropertyName("condicao")]
        public string? Condicao { get; set; }

        [JsonPropertyName("condicao_Desc")]
        public string? CondicaoDesc { get; set; }

        [JsonPropertyName("temp")]
        public float? Temp { get; set; }
    }
}