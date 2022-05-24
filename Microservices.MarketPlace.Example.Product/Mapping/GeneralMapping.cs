using Microservices.MarketPlace.Example.Product.Dtos;
using AutoMapper;
using Microservices.MarketPlace.Example.Product.Models;

namespace Microservices.MarketPlace.Example.Product.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Models.Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
        }
   
    }
}
