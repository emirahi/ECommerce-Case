using ECommerce.Business.ConCreate;
using ECommerce.Business.FluentValidation;
using ECommerce.Core;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.ConCreate;
using ECommerce.DataAccess.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Test;

public class Utility
{
    public ServiceProvider ServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddDbContext<ECommerceDBContext>(x =>
        {
            x.UseInMemoryDatabase("test-db");
            x.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        });
        
        services.AddAutoMapper(conf => conf.AddMaps(typeof(UserManager).Assembly)); 
        services.AddValidatorsFromAssemblyContaining<UserDtoValidation>();
        
        services.CreateServices();
        
        return services.BuildServiceProvider();
    }
}