using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimaBrasil.Infrastructure.Shared
{
    public static class Map
    {
        public static string GetCidadeClimaTable()
        {
            return "[dbo].[CidadeClima]";
        }

        public static string GetClimaTable()
        {
            return "[dbo].[Clima]";
        }

        public static string GetAeroportoClimaTable()
        {
            return "[dbo].[AeroportoClima]";
        }
        
    }
}