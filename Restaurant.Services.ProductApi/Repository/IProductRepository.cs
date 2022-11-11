using Restaurant.Services.ProductApi.Models.Dtos;

namespace Restaurant.Services.ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<bool> DeleteProduct(int productId);
        Task<ProductDto> UpsertProduct(ProductDto productDto);
        Task<ProductDto> GetProductById(int productId);
        Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}
