using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.WatchListQueries.GetWatchListByUserQueries
{
    public class GetWatchListByUserQueriesHandler : IQueryHandler<GetWatchListByUserQueries, List<Content>>
    {
        private readonly IWatchListService _watchListService;

        public GetWatchListByUserQueriesHandler(IWatchListService watchListService)
        {
            _watchListService = watchListService;
        }

        public async Task<List<Content>> Handle(GetWatchListByUserQueries request, CancellationToken cancellationToken)
        {
            return await _watchListService.GetWithUser(request.UserId);
        }
    }
}
