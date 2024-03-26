using AutoMapper;
using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Domain.Entities;

namespace ClimaBrasil.Application.BrasilApiRest.Mapping
{
    public class AeroportoEntityDTOMapping : Profile
    {
        public AeroportoEntityDTOMapping()
        {
            CreateMap<AeroportoEntity, AeroportoResponse>();
            CreateMap<AeroportoResponse, AeroportoEntity>();
        }
    }
}