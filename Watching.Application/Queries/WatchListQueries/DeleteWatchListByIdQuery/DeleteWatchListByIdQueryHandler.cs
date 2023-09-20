using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.WatchListQueries.DeleteWatchListByIdQuery
{
    public class DeleteWatchListByIdQueryHandler : IQueryHandler<DeleteWatchListByIdQuery, List<WatchList>>
    {
        private readonly IWatchListService _watchListService;

        public DeleteWatchListByIdQueryHandler(IWatchListService watchListService)
        {
            _watchListService = watchListService;
        }

        public async Task<List<WatchList>> Handle(DeleteWatchListByIdQuery request, CancellationToken cancellationToken)
        {
            await _watchListService.DeleteEntity(request.Id);
            return await _watchListService.GetWatchListAsync();
        }
    }
}
