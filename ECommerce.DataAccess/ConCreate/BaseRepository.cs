using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Context;
using ECommerce.Entity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.ConCreate;

public class BaseRepository<T> : IBaseRepository<T>  where T: class,IBaseEntity
{
    public DbSet<T> _dbSet;
    public ECommerceDBContext _dbContext;

    public BaseRepository(ECommerceDBContext  dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x =>  x.Id == id);
    }

    public async Task<T> AddAsync(T entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        return entry.Entity;
    }

    public T Update(T entity)
    {
        var entry = _dbSet.Update(entity);
        return entry.Entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        var entry = _dbSet.Remove(entity);
        return entry.Entity;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }
}