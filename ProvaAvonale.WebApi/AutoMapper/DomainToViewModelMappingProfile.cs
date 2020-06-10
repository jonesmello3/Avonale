using AutoMapper;
using ProvaAvonale.Domain.Entities;
using ProvaAvonale.WebApi.Models.ViewModel;

namespace ProvaAvonale.WebApi.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Repositorio, RepositorioViewModel>();
        }

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
    }
}