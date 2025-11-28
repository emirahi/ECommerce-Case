using ECommerce.Business.Abstract;
using ECommerce.Business.ConCreate;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.ConCreate;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core;

public static class Configurations
{
    public static void CreateServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IOrderService, OrderManager>();

        services.AddLogging();

    }
    
}
