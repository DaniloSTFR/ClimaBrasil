using AutoMapper;
using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Application.BrasilApiRest.Models;

namespace ClimaBrasil.Application.BrasilApiRest.Mapping
{
    public class CidadeMapping : Profile
    {
       
        public CidadeMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<CidadeResponse, CidadeModel>();
            CreateMap<CidadeModel, CidadeResponse>();
        }


    }
}