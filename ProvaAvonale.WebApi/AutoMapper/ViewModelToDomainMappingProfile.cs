using AutoMapper;
using ProvaAvonale.Domain.Entities;
using ProvaAvonale.WebApi.Models.ViewModel;

namespace ProvaAvonale.WebApi.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RepositorioViewModel, Repositorio>();
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
    }
}