using ECommerce.Business.Response;
using ECommerce.Entity;

namespace ECommerce.Business.Abstract;

public interface IUserService
{
    Task<ResponseObject<UserDto>> GetByIdAsync(int id);
    Task<ResponseObject<UserDto>> AddAsync(UserCreateDto user);
    ResponseObject<UserDto> Update(UserDto userDto);
    Task<ResponseObject<UserDto>> DeleteAsync(UserDto userDto);
}