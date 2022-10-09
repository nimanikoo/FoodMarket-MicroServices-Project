using AutoMapper;
using Restaurant.Services.ProductApi.Models;
using Restaurant.Services.ProductApi.Models.Dtos;

namespace Restaurant.Services.ProductApi
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product,ProductDto>();
        }
    }
}
