using ECommerce.Business.Abstract;
using ECommerce.Entity;
using Microsoft.Extensions.DependencyInjection;
using NuGet.ContentModel;

namespace ECommerce.Test;

public class OrderTest
{
    [Fact]
    public async Task OrderCreate_Success()
    {
        Utility utility = new Utility();
        var provider = utility.ServiceProvider();
        var userService = provider.GetRequiredService<IUserService>();
        var productService = provider.GetRequiredService<IProductService>();
        var orderService = provider.GetRequiredService<IOrderService>();

        var user = await userService.AddAsync(new()  {  name = "Emir", email = "emirahi45@gmail.com" });
        var product = await productService.AddAsync(new() { Name = "ürün 1", Stock = 500, Price = new decimal(12.90) });

        if (user.Status &&  product.Status)
        {
            var order = await orderService.AddAsync(new OrderCreateDto()
            {
                UserId = user.Entity.Id,
                ProductId = product.Entity.Id,
                Quantity = 250
            });
            
            var updatedProduct = await productService.GetByIdAsync(product.Entity.Id);
            if (updatedProduct != null && updatedProduct.Entity != null)
                Assert.Equal(updatedProduct.Entity.Stock, 250);
            
        }
        Assert.True(user.Status &&  product.Status);
    }
    
    [Fact]
    public async Task OrderCreate_FaildForUserId()
    {
        Utility utility = new Utility();
        var provider = utility.ServiceProvider();
        var productService = provider.GetRequiredService<IProductService>();
        var orderService = provider.GetRequiredService<IOrderService>();
        
        var product = await productService.AddAsync(new() { Name = "ürün 1", Stock = 500, Price = new decimal(12.90) });

        if (product.Status)
        {
            var order = await orderService.AddAsync(new OrderCreateDto()
            {
                UserId = -1,
                ProductId = product.Entity.Id,
                Quantity = 250
            });
            Assert.False(order.Status);
            return;
        }
        Assert.True(product.Status);
    }
    
    [Fact]
    public async Task OrderCreate_FaildForProductId()
    {
        Utility utility = new Utility();
        var provider = utility.ServiceProvider();
        var userService = provider.GetRequiredService<IUserService>();
        var orderService = provider.GetRequiredService<IOrderService>();

        var user = await userService.AddAsync(new()  {  name = "Emir", email = "emirahi45@gmail.com" });

        if (user.Status)
        {
            var order = await orderService.AddAsync(new OrderCreateDto()
            {
                UserId = user.Entity.Id,
                ProductId = 0,
                Quantity = 250
            });
            Assert.False(order.Status);
            return;
        }
        Assert.True(user.Status);
    }
    
}