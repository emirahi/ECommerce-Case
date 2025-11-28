using ECommerce.Entity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Abstract;

public interface IBaseRepository<T>  where T : class,IBaseEntity
{
    public Task<T?> GetByIdAsync(int id);
    public Task<T> AddAsync(T entity);
    public T Update(T entity);
    public Task<T> DeleteAsync(T entityr);
    public Task<int> SaveChangesAsync();
    public int SaveChanges();
    
}