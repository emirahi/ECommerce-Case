using ECommerce.Business.Abstract;
using ECommerce.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Test;

public class ProductTest
{
    [Fact]
    public async Task ProductCreate_Success()
    {
        Utility utility = new Utility();
        var provider = utility.ServiceProvider();
        var productService = provider.GetRequiredService<IProductService>();
        ProductCreateDto productCreateDto = new ProductCreateDto()
        {
            Name = "Ürün Adı",
            Stock = 500,
            Price = new decimal(12.90)
        };
        var result = await productService.AddAsync(productCreateDto);
        Assert.True(result.Status);
    }

    [Fact]
    public async Task ProductCreate_FailForLengthName()
    {
        Utility utility = new Utility();
        var provider = utility.ServiceProvider();
        var productService = provider.GetRequiredService<IProductService>();
        ProductCreateDto productCreateDto = new ProductCreateDto()
        {
            Name = "",
            Stock = 500,
            Price = new decimal(12.90)
        };
        var result = await productService.AddAsync(productCreateDto);
        Assert.False(result.Status);
    }
    
    [Fact]
    public async Task ProductCreate_FailForZeroStock()
    {
        Utility utility = new Utility();
        var provider = utility.ServiceProvider();
        var productService = provider.GetRequiredService<IProductService>();
        ProductCreateDto productCreateDto = new ProductCreateDto()
        {
            Name = "Ürün 1",
            Stock = 0,
            Price = new decimal(12.90)
        };
        var result = await productService.AddAsync(productCreateDto);
        Assert.False(result.Status);
    }
    
    [Fact]
    public async Task ProductCreate_FailForZeroPrice()
    {
        Utility utility = new Utility();
        var provider = utility.ServiceProvider();
        var productService = provider.GetRequiredService<IProductService>();
        ProductCreateDto productCreateDto = new ProductCreateDto()
        {
            Name = "Ürün 1",
            Stock = 500,
            Price = 0
        };
        var result = await productService.AddAsync(productCreateDto);
        Assert.False(result.Status);
    }
    
}