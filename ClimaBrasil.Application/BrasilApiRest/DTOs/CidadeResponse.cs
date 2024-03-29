
using System.Collections;

namespace ClimaBrasil.Application.BrasilApiRest.DTOs
{
    public class CidadeResponse
    {
        public int? CodigoCidade { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public List<ClimaResponse>? Clima { get; set; }
        public string? RotaRequest { get; set; } 
    }
}