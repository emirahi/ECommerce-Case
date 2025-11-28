using ECommerce.Business.Response;
using ECommerce.Entity;

namespace ECommerce.Business.Abstract;

public interface IProductService
{
    Task<ResponseObject<ProductDto>> GetByIdAsync(int productId);
    Task<ResponseObject<ProductDto>> AddAsync(ProductCreateDto productCreateDto);
    Task<ResponseObject<ProductDto>> UpdateAsync(int id,int stock);
    
    
}