using AutoMapper;
using ClimaBrasil.API.DTOs;
using ClimaBrasil.API.Models;

namespace ClimaBrasil.API.Mapping
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