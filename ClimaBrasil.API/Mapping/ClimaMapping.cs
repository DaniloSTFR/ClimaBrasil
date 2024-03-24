using AutoMapper;
using ClimaBrasil.API.DTOs;
using ClimaBrasil.API.Models;

namespace ClimaBrasil.API.Mapping
{
    public class ClimaMapping : Profile
    {
        public ClimaMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<ClimaResponse, ClimaModel>();
            CreateMap<ClimaModel, ClimaResponse>();
        }
    }
}