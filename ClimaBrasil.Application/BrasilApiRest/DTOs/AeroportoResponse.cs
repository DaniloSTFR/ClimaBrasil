using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimaBrasil.Application.BrasilApiRest.DTOs
{
    public class AeroportoResponse
    {
        public string? CodigoAeroporto { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public int? PressaoAtmosferica { get; set; }
        public string? Visibilidade { get; set; }
        public int? Vento { get; set; }
        public int? DirecaoVento { get; set; }
        public int? Umidade { get; set; }
        public string? Condicao { get; set; }
        public string? CondicaoDesc { get; set; }
        public float? Temp { get; set; }   
        public string? RotaRequest { get; set; }      
    }
}