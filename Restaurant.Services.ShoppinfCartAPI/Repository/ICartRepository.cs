using Restaurant.Services.ShoppingCartApi.Models.Dtos;

namespace Restaurant.Services.ShoppingCartApi.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> UpsertCart(CartDto cartDto);
        Task<bool> DeleteFromCart(int cartDetailId);
        Task<bool> ClearCart(string userId);

    }
}
