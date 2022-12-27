using MoeSystem.Shared.Models;
using System.Linq.Expressions;

namespace MoeSystem.Server.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<TResult> GetAsync<TResult>(int? id);
        Task<List<T>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>();
        Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, bool>> expression);
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);
        Task<T> AddAsync(T entity, HttpContext context);
        Task<TResult> AddAsync<TSource, TResult>(TSource source, HttpContext context);
        Task DeleteAsync(int id);
        Task<T> UpdateAsync(T entity, HttpContext context);
        Task<T> UpdateAsync<TSource>(int? id, TSource source, HttpContext context);
        Task<bool> Exists(int id);
    }
}
