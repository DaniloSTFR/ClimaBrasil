using AutoMapper;
using ClimaBrasil.API.DTOs;
using ClimaBrasil.API.Models;

namespace ClimaBrasil.API.Mapping
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