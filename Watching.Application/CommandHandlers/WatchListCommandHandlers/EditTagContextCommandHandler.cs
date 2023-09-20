using Watching.Application.Dtos;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.CommandHandlers.WatchListCommandHandlers
{
    public class EditTagContextCommandHandler : BaseCommandHandler<TagContent, List<Content2WatchList>>
    {
        private readonly IWatchListService _watchListService;

        public EditTagContextCommandHandler(IWatchListService watchListService)
        {
            _watchListService = watchListService;
        }

        public async override Task<List<Content2WatchList>> Handle(TagContent command, CancellationToken cancellationToken)
        {
            await _watchListService.UpdateIsTaggedAsync(command);
            return await _watchListService.GetContent2WatchListsAsync();
        }
    }
}
