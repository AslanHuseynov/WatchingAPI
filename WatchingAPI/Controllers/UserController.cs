using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watching.Application.Dtos.UserDto;
using Watching.Application.Interfaces;
using Watching.Application.Queries.UserQueries.DeleteUserByIdQuery;
using Watching.Application.Queries.UserQueries.GetUserByIdQuery;
using Watching.Application.Queries.UserQueries.GetUserQueries;
using Watching.Model.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IUserService userService, IMapper mapper)
        {
            _mediatR = mediator;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers([FromQuery]GetUserQueries queries)
        {
            return await _mediatR.Send(queries);
        }

        [HttpGet("id")]
        public async Task<ActionResult<User>> GetUser([FromQuery]GetUserByIdQuery query)
        {
            var result = await _mediatR.Send(query);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(CreateUserCommand command) 
            => await _mediatR.Send(command);

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(UpdateUserCommand command) 
            => await _mediatR.Send(command);

        [HttpDelete("id")]
        public async Task<ActionResult<List<User>>> DeleteUser([FromQuery]DeleteUserByIdQuery query)
        {
            var result = await _mediatR.Send(query);
            if (result is null) 
                return NotFound();

            return Ok(result);
        }
    }
}
