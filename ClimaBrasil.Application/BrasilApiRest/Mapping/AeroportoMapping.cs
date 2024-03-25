using AutoMapper;
using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Application.BrasilApiRest.Models;

namespace ClimaBrasil.Application.BrasilApiRest.Mapping
{
    public class AeroportoMapping : Profile
    {
        public AeroportoMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<AeroportoResponse, AeroportoModel>();
            CreateMap<AeroportoModel, AeroportoResponse>();
        }
        
    }
}