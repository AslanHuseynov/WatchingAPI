using Watching.Application.Commands;
using Watching.Model.Models;

namespace Watching.Application.Dtos.UserDto
{
    public class UpdateUserCommand : BaseCommand<User>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}