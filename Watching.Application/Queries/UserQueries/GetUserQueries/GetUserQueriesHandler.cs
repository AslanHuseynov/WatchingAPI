using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.UserQueries.GetUserQueries
{
    public class GetUserQueriesHandler : IQueryHandler<GetUserQueries, List<User>>
    {
        private readonly IUserService _userService;

        public GetUserQueriesHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<User>> Handle(GetUserQueries request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllEntity();
        }
    }
}
