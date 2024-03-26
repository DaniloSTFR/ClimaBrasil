using AutoMapper;
using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Domain.Entities;


namespace ClimaBrasil.Application.BrasilApiRest.Mapping
{
    public class ClimaEntityDTOMapping : Profile
    {
        public ClimaEntityDTOMapping()
        {
            CreateMap<ClimaEntity, ClimaResponse>();
            CreateMap<ClimaResponse, ClimaEntity>();
            
        }
    }
}