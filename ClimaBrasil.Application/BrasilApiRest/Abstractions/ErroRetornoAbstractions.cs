using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimaBrasil.Application.BrasilApiRest.Abstractions
{
    public class ErroRetornoAbstractions
    {
        public string message { get; set; }
        public string type { get; set; }
        public string name { get; set; }
    }
}