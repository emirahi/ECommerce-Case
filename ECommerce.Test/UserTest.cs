using ECommerce.Business.Abstract;
using ECommerce.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Test;

public class UserTest
{
    [Fact]
    public async Task UserCreate_Success()
    {
        Utility utility = new Utility();
        var provider = utility.ServiceProvider();

        var userService = provider.GetRequiredService<IUserService>();

        var result = await userService.AddAsync(new UserCreateDto()
        {
            name = "Emir",
            email = "emirahi45@gmail.com"
        });
        
        Assert.True(result.Status);
    }

    [Fact]
    public async Task UserCreate_FailForEmail()
    {
        Utility utility = new Utility();
        var provider = utility.ServiceProvider();
        var userService = provider.GetRequiredService<IUserService>();

        var result = await userService.AddAsync(new UserCreateDto()
        {
            email = "bu bir mail değil",
            name = "Emir",
        });
        
        Assert.False(result.Status);
    }
    
    [Fact]
    public async Task UserCreate_FailForLengthName()
    {
        Utility utility = new Utility();
        var provider = utility.ServiceProvider();
        var userService = provider.GetRequiredService<IUserService>();

        var result = await userService.AddAsync(new UserCreateDto()
        {
            name = "",
            email = "emirahi45@gmail.com",
        });
        
        Assert.False(result.Status);
    }
    
}