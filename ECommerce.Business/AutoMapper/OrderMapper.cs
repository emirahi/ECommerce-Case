using AutoMapper;
using ECommerce.Entity;

namespace ECommerce.Business.AutoMapper;

public class OrderMapper:Profile
{
    public OrderMapper()
    {
        CreateMap<Order,OrderDto>().ReverseMap();
        CreateMap<Order, OrderCreateDto>().ReverseMap();
    }
}