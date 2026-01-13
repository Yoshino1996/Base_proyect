
using AutoMapper;
using Base_proyect.DTOs;
using Base_proyect.Models;

namespace Base_proyect.Mapping
{
    public class ProductProfile: Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }

    }
}
