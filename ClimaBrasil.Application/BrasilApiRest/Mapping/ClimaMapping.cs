using AutoMapper;
using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Application.BrasilApiRest.Models;

namespace ClimaBrasil.Application.BrasilApiRest.Mapping
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