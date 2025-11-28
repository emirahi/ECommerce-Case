using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.Response;
using ECommerce.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
        }
        
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody]UserCreateDto userDto)
        {
            ResponseObject<UserDto> response = await _userService.AddAsync(userDto);
            if (response.Status)
                return Ok(response);
            return BadRequest(response);
        }
        
    }
}
