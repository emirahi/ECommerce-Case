using ECommerce.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerce.DataAccess.Context;

public class ECcommerceDBContextFactory : IDesignTimeDbContextFactory<ECommerceDBContext>
{
    
    public ECommerceDBContext CreateDbContext(string[] args)
    {
        string? connectionString = GlobalConfigurations.GetConnectionString();
        if (!string.IsNullOrEmpty(connectionString))
            throw new Exception("Connection string not configured");
        
        var options = new DbContextOptionsBuilder<ECommerceDBContext>()
            .UseMySQL(connectionString)
            .Options;

        return new ECommerceDBContext(options);
    }

}
