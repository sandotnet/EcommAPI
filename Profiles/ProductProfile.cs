using AutoMapper;
using EcommAPI.DTOs;
using EcommAPI.Entities;

namespace EcommAPI.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            //defind mapping between dto and entity
            CreateMap<ProductDto, Product>();
            CreateMap<Product,ProductDto>();
        }
    }
}
