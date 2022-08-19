using FlixNTix.Data.Base;
using FlixNTix.Models;

namespace FlixNTix.Data.Base_Interfaces;

public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(int id, T entity);
    Task DeleteAsync(int id);
}
