using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Context;
using ECommerce.Entity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.ConCreate;

public class OrderRepository:BaseRepository<Order>,IOrderRepository
{
    public OrderRepository(ECommerceDBContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Order>> GetHistoryByUserAsync(int userId)
    {
        return await _dbSet.AsNoTracking().Where(order => order.UserId == userId).ToListAsync();
    }
}