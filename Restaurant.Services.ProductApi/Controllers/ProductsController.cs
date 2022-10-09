using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.ProductApi.Data;
using Restaurant.Services.ProductApi.Models;
using Restaurant.Services.ProductApi.Models.Dtos;
using Restaurant.Services.ProductApi.Respository;

namespace Restaurant.Services.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        protected ResponseDto _responseDto;
        public ProductsController(IProductRepository repository)
        {
            _repo = repository;
            this._responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<Object> GetAll()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _repo.GetAllProducts();
                _responseDto.Result = productDtos;
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        [HttpGet("{id}")]
        public async Task<Object> GetById(int id)
        {
            try
            {
                ProductDto productDto = await _repo.GetProductById(id);
                _responseDto.Result = productDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        [HttpPost]
        public async Task<object> CreatetProduct([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto newProduct = await _repo.UpsertProduct(productDto);
                _responseDto.Result = newProduct;

            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        [HttpPut]
        public async Task<object> UpdateProduct([FromBody] ProductDto productDto)
        {
            try
            {
              ProductDto existProduct = await _repo.UpsertProduct(productDto);
                _responseDto.Result = existProduct;
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDto;

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> DeleteProduct(int id)
        {
            try
            {
                bool successDelete = await _repo.DeleteProduct(id);
                _responseDto.Result=successDelete;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }
    }
}
