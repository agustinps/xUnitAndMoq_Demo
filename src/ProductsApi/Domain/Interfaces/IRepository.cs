using ProductsApi.Domain.Entities;
using System.Linq.Expressions;

namespace ProductsApi.Domain.Interfaces
{
 
    //Interfaz para el repositorio genérico
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<bool> SaveChangesAsync();
        Task<bool> DeleteAsync(int id);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
