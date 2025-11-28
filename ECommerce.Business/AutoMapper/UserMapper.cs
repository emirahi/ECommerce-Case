using AutoMapper;
using ECommerce.Entity;

namespace ECommerce.Business.AutoMapper;

public class UserMapper:Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserCreateDto>().ReverseMap();
    }
    
}