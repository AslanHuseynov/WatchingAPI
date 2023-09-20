using Watching.Application.Dtos.WatchListDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.CommandHandlers.WatchListCommandHandlers
{
    public class AddToWatchListCommandHandler : BaseCommandHandler<AddToWatchListCommand, Content2WatchList>
    {
        private readonly IWatchListService _watchListService;

        public AddToWatchListCommandHandler(IWatchListService watchListService)
        {
            _watchListService = watchListService;
        }

        public async override Task<Content2WatchList> Handle(AddToWatchListCommand command, CancellationToken cancellationToken)
        {
            return await _watchListService.AddToWatchList(command.ContenetId, command.UserId);
        }
    }
}
