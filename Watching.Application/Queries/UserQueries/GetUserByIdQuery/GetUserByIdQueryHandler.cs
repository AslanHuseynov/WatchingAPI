using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.UserQueries.GetUserByIdQuery
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
    {
        private readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetEntity(request.Id);
        }
    }
}
