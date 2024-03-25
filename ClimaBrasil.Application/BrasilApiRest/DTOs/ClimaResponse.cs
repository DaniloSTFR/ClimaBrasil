
namespace ClimaBrasil.Application.BrasilApiRest.DTOs
{
    public class ClimaResponse
    {
        public DateTime? Data { get; set; }
        public string? Condicao { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public float? IndiceUv { get; set; }
        public string? CondicaoDesc { get; set; }
    }
}