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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userRepository.GetAllEntity();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var result = await _userRepository.GetEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            var result = await _userRepository.AddEntity(user);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(UpdateUserDto updateUserDto)
        {
            var user = _mapper.Map<User>(updateUserDto);
            var result = await _userRepository.UpdateEntity(updateUserDto.Id, user);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteEntity(id);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
