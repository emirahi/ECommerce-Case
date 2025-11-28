using ECommerce.Entity;

namespace ECommerce.DataAccess.Abstract;

public interface IOrderRepository:IBaseRepository<Order>
{
    Task<List<Order>> GetHistoryByUserAsync(int userId);
}