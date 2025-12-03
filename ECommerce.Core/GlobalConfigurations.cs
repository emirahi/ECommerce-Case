using Microsoft.Extensions.Configuration;

namespace ECommerce.Core;

public static class GlobalConfigurations
{
    public static string? GetConnectionString()
    {
        var basePath = Path.GetFullPath(
            Path.Combine(Directory.GetCurrentDirectory(), "..", "ECommerce.WebApi")
        );

        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        
        return config["Mysql"];
    }
    
}