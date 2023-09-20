using AutoMapper;
using Watching.Application.Dtos.UserDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.CommandHandlers.UserCommandHandlers
{
    public class UpdateUserCommandHandler : BaseCommandHandler<UpdateUserCommand, User>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async override Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(command);
            return await _userService.UpdateEntity(command.Id, user);
        }
    }
}
