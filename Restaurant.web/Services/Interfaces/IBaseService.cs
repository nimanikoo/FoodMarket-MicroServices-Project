using Restaurant.web.Models;

namespace Restaurant.web.Services.Interfaces
{
    public interface IBaseService:IDisposable
    {
        ResponseDto responseObject { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
