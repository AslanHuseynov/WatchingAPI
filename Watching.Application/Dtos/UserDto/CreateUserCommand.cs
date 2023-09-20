using Watching.Application.Commands;
using Watching.Model.Models;

namespace Watching.Application.Dtos.UserDto
{
    public class CreateUserCommand : BaseCommand<User>
    {
        public string FullName { get; set; }
    }
}
