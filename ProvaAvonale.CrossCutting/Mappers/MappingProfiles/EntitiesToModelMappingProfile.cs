using AutoMapper;
using ProvaAvonale.ApplicationService.Models;
using ProvaAvonale.Domain.Entities;

namespace ProvaAvonale.CrossCutting.Mappers.MappingProfiles
{
    public class EntitiesToModelMappingProfile : Profile
    {
        public EntitiesToModelMappingProfile()
        {
            CreateMap<Repositorio, RepositorioDTO>().ReverseMap();
            
        }
    }
}
