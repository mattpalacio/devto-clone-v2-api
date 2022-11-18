using AutoMapper;
using DevtoCloneV2.Api.DTOs.User;
using DevtoCloneV2.Core.Entities;
using DevtoCloneV2.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace DevtoCloneV2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var usersDto = _mapper.Map<IEnumerable<User>>(users);
            return Ok(usersDto);
        }

        [HttpGet("email")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            var userDto = _mapper.Map<User>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto newUserDto)
        {
            var newUser = _mapper.Map<User>(newUserDto);
            await _userService.CreateUser(newUser);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequestDto updatedUserDto)
        {
            var updatedUser = _mapper.Map<User>(updatedUserDto);
            await _userService.UpdateUser(id, updatedUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
