using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.ShoppingCartApi.Models.Dtos;
using Restaurant.Services.ShoppingCartApi.Repository;

namespace Restaurant.Services.ShoppingCartApi.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private ResponseDto _responseDto;

        public CartController(ICartRepository cartRepository, ResponseDto responseDto)
        {
            _cartRepository = cartRepository;
            _responseDto = responseDto;
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(userId);
                _responseDto.Result = cartDto;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>
                {
                ex.ToString()
                };
            }
            return _responseDto;
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart(CartDto cartDto)
        {
            try
            {
                CartDto cartDt = await _cartRepository.UpsertCart(cartDto);
                _responseDto.Result = cartDt;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>
                {
                ex.ToString()
                };
            }
            return _responseDto;
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart(CartDto cartDto)
        {
            try
            {
                CartDto cartDt = await _cartRepository.UpsertCart(cartDto);
                _responseDto.Result = cartDt;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>
                {
                ex.ToString()
                };
            }
            return _responseDto;
        }

        [HttpPost("DeleteCart")]
        public async Task<object> DeleteCart([FromBody] int cartId)
        {
            try
            {
                bool successDelete = await _cartRepository.DeleteFromCart(cartId);
                _responseDto.Result = successDelete;

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>
                {
                ex.ToString()
                };
            }
            return _responseDto;
        }
    }
}
