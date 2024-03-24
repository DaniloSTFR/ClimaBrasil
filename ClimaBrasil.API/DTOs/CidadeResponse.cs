
using System.Collections;

namespace ClimaBrasil.API.DTOs
{
    public class CidadeResponse
    {
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public List<ClimaResponse>? Clima { get; set; }
    }
}