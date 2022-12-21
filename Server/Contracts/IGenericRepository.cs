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
        Task<T> AddAsync(T entity);
        Task<TResult> AddAsync<TSource, TResult>(TSource source);
        Task DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<T> UpdateAsync<TSource>(int? id, TSource source);
        Task<bool> Exists(int id);
    }
}
