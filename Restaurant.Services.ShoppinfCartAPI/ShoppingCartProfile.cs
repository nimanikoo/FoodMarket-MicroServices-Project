using AutoMapper;
using Restaurant.Services.ShoppingCartApi.Models;
using Restaurant.Services.ShoppingCartApi.Models.Dtos;

namespace Restaurant.Services.ShoppingCartApi
{
    public class ShoppingCartProfile
    {
        public class ProductProfile : Profile
        {
            public ProductProfile()
            {
                CreateMap<ProductDto, Product>();
                CreateMap<Product, ProductDto>();

                CreateMap<CartHeader, CartHeaderDto>();
                CreateMap<CartHeaderDto, CartHeader>();

                CreateMap<CartDetail, CartDetailDto>();
                CreateMap<CartDetailDto, CartDetail>();

                CreateMap<Cart, CartDto>();
                CreateMap<CartDto, Cart>();

            }
        }
    }
}
