using AutoMapper;
using TechMarket.BLL.DTO;
using TechMarket.Data.Db.Entities;

namespace TechMarket.BLL.Infrastructure
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            // Profile for Product
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Characteristic, CharacteristicsDTO>().ReverseMap();
            CreateMap<CharacteristicProduct, CharacteristicProductDTO>().ReverseMap();

            //Profile for Order
            CreateMap<Order, OrderDTO>().ReverseMap();

            //Identity
            CreateMap<CustomerProfile, UserDTO>().ReverseMap();
        }
    }
}
