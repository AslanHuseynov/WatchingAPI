using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.UserQueries.DeleteUserByIdQuery
{
    public class DeleteUserByIdQueryHandler : IQueryHandler<DeleteUserByIdQuery, List<User>>
    {
        private readonly IUserService _userService;

        public DeleteUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<User>?> Handle(DeleteUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteEntity(request.Id);
        }
    }
}
