using ECommerce.Business.Response;
using ECommerce.Entity;

namespace ECommerce.Business.Abstract;

public interface IOrderService
{
    Task<ResponseObject<OrderDto>> AddAsync(OrderCreateDto orderCreateDto);
    Task<ResponseObject<List<OrderDto>>> GetHistoryByUserAsync(int userId);
    
}