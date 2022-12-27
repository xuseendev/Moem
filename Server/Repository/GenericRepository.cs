using AutoMapper;
using AutoMapper.QueryableExtensions;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Exceptions;

using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Data;
using System.Linq;
using System.Linq.Expressions;
using MoeSystem.Shared.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace MoeSystem.Server.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> userManager;

        public GenericRepository(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            this._mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<TResult> AddAsync<TSource, TResult>(TSource source, HttpContext context)
        {
            var entity = _mapper.Map<T>(source);
            await _context.AddAsync(entity);
            await Save(context);
            return _mapper.Map<TResult>(entity);
        }

        public async Task<T> AddAsync(T entity, HttpContext context)
        {
            await _context.AddAsync(entity);
            await Save(context);
            return entity;
        }

        public async Task Save(HttpContext httpContext)
        {
            //var user = httpContext.User.Identity.Name;
            var userId = httpContext.User.FindFirst("uid").Value;
            var user = await userManager.FindByIdAsync(userId);
            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified || q.State == EntityState.Added);
            foreach (var entry in entries)
            {
                ((BaseModel)entry.Entity).UpdatedOn = DateTime.Now;
                ((BaseModel)entry.Entity).UpdateBy = user.UserName;
                if (entry.State == EntityState.Added)
                {
                    ((BaseModel)entry.Entity).CreatedOn = DateTime.Now;
                    ((BaseModel)entry.Entity).CreatedBy = user.UserName;

                }

            }
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity is null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<TResult>> GetAllAsync<TResult>()
        {
            return await _context.Set<T>().ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync();
        }



        public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters)
        {
            var totalSize = await _context.Set<T>().CountAsync();
            var data = await _context.Set<T>()
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return new PagedResult<TResult>
            {
                Data = data,
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSize

            };

        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }





        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<TResult> GetAsync<TResult>(int? id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result is null)
            {
                throw new NotFoundException(typeof(T).Name, id.HasValue ? id : "No Key Provided");
            }
            return _mapper.Map<TResult>(result);
        }

        public async Task<T> UpdateAsync(T entity, HttpContext context)
        {
            _context.Update(entity);
            await Save(context);
            return entity;
        }

        public async Task<T> UpdateAsync<TSource>(int? id, TSource source, HttpContext context)
        {
            if (id == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }
            var entity = await GetAsync(id);
            if (entity is null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }
            _mapper.Map(source, entity);
            _context.Update(entity);
            await Save(context);
            return entity;
        }
    }
}
