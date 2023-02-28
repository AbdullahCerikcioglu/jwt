using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Persistance.Context;

namespace Udemy.JwtApp.Api.Persistance.Repositories
{
    public class Repository_T_<T> : IRepository<T> where T : class, new()
    {

        private readonly JwtContext _jwtContext;

        public Repository_T_(JwtContext jwtContext)
        {
            _jwtContext = jwtContext;
        }

        public async Task CreateAsync1(T entity)
        {
           await _jwtContext.Set<T>().AddAsync(entity);
           await _jwtContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync1()
        {
          return await _jwtContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync3(Expression<Func<T, bool>> filter)
        {
             return await _jwtContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync2(object id)
        {
            return await _jwtContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync3(T entity)
        {
           _jwtContext.Set<T>().Remove(entity);
            await _jwtContext.SaveChangesAsync();
        }

        public async Task UpdateAsync2(T entity)
        {
            _jwtContext.Set<T>().Update(entity);
            await _jwtContext.SaveChangesAsync();
        }
    }
}
