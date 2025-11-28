using AutoMapper;
using ECommerce.Entity;

namespace ECommerce.Business.AutoMapper;

public class ProductMapper:Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
    }
    
}