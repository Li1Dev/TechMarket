using AutoMapper;
using TechMarket.BLL.DTO;
using TechMarket.Models;

namespace TechMarket.BLL.Infrastructure
{
    internal class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile() {
            CreateMap<ProductDTO, ProductViewModel>().ReverseMap();
            CreateMap<CompanyDTO, CompanyViewModel>().ReverseMap();
            CreateMap<CategoryDTO, CategoryViewModel>().ReverseMap();
            CreateMap<CharacteristicsDTO, CharacteristicViewModel>().ReverseMap();
            CreateMap<CharacteristicProductDTO, CharacteristicProductViewModel>().ReverseMap();
        }
    }
}
