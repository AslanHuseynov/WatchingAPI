using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Watching.Application.Dtos.UserDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace WatchingAPI.Controllers
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
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userService.GetAllEntity();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var result = await _userService.GetEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            var result = await _userService.AddEntity(user);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(UpdateUserDto updateUserDto)
        {
            var user = _mapper.Map<User>(updateUserDto);
            var result = await _userService.UpdateEntity(updateUserDto.Id, user);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = await _userService.DeleteEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
