using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.Exceptions;
using ECommerce.Business.FluentValidation;
using ECommerce.Business.Response;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entity;
using Utility = ECommerce.Core.Utility;

namespace ECommerce.Business.ConCreate;

public class UserManager:IUserService
{
    private IUserRepository _userRepository;
    private IMapper _mapper;
    public UserManager(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<ResponseObject<UserDto>> GetByIdAsync(int id)
    {
        ResponseObject<UserDto> responseUserDto = new ResponseObject<UserDto>();
        
        User? user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new NullReferenceException();

        responseUserDto.Status = true;
        responseUserDto.Entity = _mapper.Map<UserDto>(user);
        return responseUserDto;
    }

    public async Task<ResponseObject<UserDto>> AddAsync(UserCreateDto userDto)
    {
        ResponseObject<UserDto> returnedUserDto = new ResponseObject<UserDto>();
        
        var validationResult = Utility.Validator(userDto, new UserCreateDtoValidation());
        if (!validationResult.IsValid)
        {
            returnedUserDto.Errors = validationResult.messages.Select(message => message.ErrorMessage).ToList();
            return returnedUserDto;
        }

        User user = _mapper.Map<User>(userDto);
        User responseUser = await _userRepository.AddAsync(user);
        int changeCount = await _userRepository.SaveChangesAsync();
        
        returnedUserDto.Status = true;
        returnedUserDto.Entity = _mapper.Map<UserDto>(responseUser);
        
        
        return returnedUserDto;
    }

    public ResponseObject<UserDto> Update(UserDto userDto)
    {
        ResponseObject<UserDto> returnedUserDto = new ResponseObject<UserDto>();
        
        var validationResult = Utility.Validator(userDto, new UserDtoValidation());
        if (!validationResult.IsValid)
        {
            returnedUserDto.Errors = validationResult.messages.Select(message => message.ErrorMessage).ToList();
        }
        
        User user = _mapper.Map<User>(userDto);
        User responseUser = _userRepository.Update(user);
        returnedUserDto.Entity =  _mapper.Map<UserDto>(responseUser);
        returnedUserDto.Status = true;
        
        return returnedUserDto;
    }

    public async Task<ResponseObject<UserDto>> DeleteAsync(UserDto userDto)
    {
        ResponseObject<UserDto> returnedUserDto = new ResponseObject<UserDto>();
        
        var validationResult = Utility.Validator(userDto, new UserDtoValidation());
        if (!validationResult.IsValid)
        {
            returnedUserDto.Errors = validationResult.messages.Select(message => message.ErrorMessage).ToList();
        }
        
        User user = _mapper.Map<User>(userDto);
        User responseUser = await _userRepository.DeleteAsync(user);
        
        returnedUserDto.Entity = _mapper.Map<UserDto>(responseUser);
        returnedUserDto.Status = true;
        return returnedUserDto;
        
            
    }

}