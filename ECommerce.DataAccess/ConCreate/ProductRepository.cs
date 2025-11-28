using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Context;
using ECommerce.Entity;

namespace ECommerce.DataAccess.ConCreate;

public class ProductRepository: BaseRepository<Product>,IProductRepository
{
    public ProductRepository(ECommerceDBContext dbContext) : base(dbContext)
    {
    }
}