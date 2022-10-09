using Restaurant.web.Models;

namespace Restaurant.web.Services.Interfaces
{
    public interface IProductServices:IBaseService
    {
        Task<T> GetAllProductAsync<T>();
        Task<T> GetSingleProductAsync<T>(int id);
        Task<T> CreatePoductAsync<T>(ProductDto productDto);
        Task<T> UpdatePoductAsync<T>(ProductDto productDto);
        Task<T> DeletePoductAsync<T>(int id);


    }
}
