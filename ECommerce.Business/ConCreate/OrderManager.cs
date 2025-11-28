using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.Exceptions;
using ECommerce.Business.FluentValidation.Orders;
using ECommerce.Business.Response;
using ECommerce.Core;
using ECommerce.Core.Response;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entity;

namespace ECommerce.Business.ConCreate;

public class OrderManager:IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public OrderManager(
        IOrderRepository orderRepository, 
        IProductService productService,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productService = productService;
        _mapper = mapper;
    }
    
    public async Task<ResponseObject<OrderDto>> AddAsync(OrderCreateDto orderCreateDto)
    {
        ResponseObject<OrderDto> returnedObject = new ResponseObject<OrderDto>();
        returnedObject.Status = false;
        
        ValidatorResponse response = Utility.Validator(orderCreateDto, new OrderCreateDtoValidation());
        if (!response.IsValid)
        {
            returnedObject.Status = false;
            returnedObject.Errors = response.messages.Select(err => err.ErrorMessage).ToList();
            return returnedObject;
        }
        
        ResponseObject<ProductDto> product = await _productService.GetByIdAsync(orderCreateDto.ProductId);
        if (!product.Status || product.Entity == null)
        {
            returnedObject.Message = Messages.ProductNotFound;
            return returnedObject;
        }

        if (product.Entity.Stock == 0)
            throw new InsufficientStockException(Messages.StockNotEnough);
        
        if (product.Entity.Stock < orderCreateDto.Quantity)
            throw new InsufficientStockException(Messages.StockNotEnough);
        
        int stock = product.Entity.Stock - orderCreateDto.Quantity;
        
        Order order = _mapper.Map<Order>(orderCreateDto);
        order.TotalPrice = product.Entity.Price * orderCreateDto.Quantity;
        
        await _productService.UpdateAsync(product.Entity.Id, stock);
        Order entity = await _orderRepository.AddAsync(order);
        int savedCount = await _orderRepository.SaveChangesAsync();
        if (savedCount > 0)
        {
            returnedObject.Status = true;
            returnedObject.Entity = _mapper.Map<OrderDto>(entity);
        }

        return returnedObject;
    }

    public async Task<ResponseObject<List<OrderDto>>> GetHistoryByUserAsync(int userId)
    {
        ResponseObject<List<OrderDto>> returnedObject = new ResponseObject<List<OrderDto>>();
        List<Order> orders = await _orderRepository.GetHistoryByUserAsync(userId);
        returnedObject.Entity = _mapper.Map <List<OrderDto>>(orders);
        
        return returnedObject;
    }
}