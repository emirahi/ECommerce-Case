using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ECommerce.DataAccess.Context;

public class ECcommerceDBContextFactory : IDesignTimeDbContextFactory<ECommerceDBContext>
{
    
    public ECommerceDBContext CreateDbContext(string[] args)
    {
        var basePath = Path.GetFullPath(
            Path.Combine(Directory.GetCurrentDirectory(), "..", "ECommerce.WebApi")
        );

        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var cs = config["Mysql"];

        var options = new DbContextOptionsBuilder<ECommerceDBContext>()
            .UseMySQL(cs)
            .Options;

        return new ECommerceDBContext(options);
    }

}
