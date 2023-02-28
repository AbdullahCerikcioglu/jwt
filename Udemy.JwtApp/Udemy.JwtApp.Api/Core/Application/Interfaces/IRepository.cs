using System.Linq.Expressions;

namespace Udemy.JwtApp.Api.Core.Application.Interfaces
{
    public interface IRepository<T> where T : class,new()
    {
        Task<List<T>> GetAllAsync1();
        Task<T?> GetByIdAsync2(object id);
        Task<T?> GetByFilterAsync3(Expression<Func<T,bool>> filter);

        Task CreateAsync1(T entity);
        Task UpdateAsync2(T entity);
        Task RemoveAsync3(T entity);


    }
}
