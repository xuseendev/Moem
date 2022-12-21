

namespace MoeSystem.Client.Services.Contracts
{
    public interface IHttpRepository<T> where T : class
    {
        Task<T> Get(string url, int id);
        Task<List<T>> GetAll(string url);
        Task<T> GetPagined(string url);
        Task Post(string url, T obj);
        Task Update(string url, T obj, int id);
        Task Delete(string url, int id);


    }
}
