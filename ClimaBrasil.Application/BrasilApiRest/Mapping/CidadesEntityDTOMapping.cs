using AutoMapper;
using ClimaBrasil.Application.BrasilApiRest.DTOs;
using ClimaBrasil.Application.BrasilApiRest.Models;
using ClimaBrasil.Domain.Entities;

namespace ClimaBrasil.Application.BrasilApiRest.Mapping
{
    public class CidadeEntityDTOMapping : Profile
    {
        public CidadeEntityDTOMapping()
        {
            CreateMap<CidadeEntity, CidadeResponse>();
            CreateMap<CidadeResponse, CidadeEntity>();
        }
    }
}