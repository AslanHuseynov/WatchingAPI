using AutoMapper;
using Watching.Application.Dtos.WatchListDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.CommandHandlers.WatchListCommandHandlers
{
    public class CreateWatchListCommandHandler : BaseCommandHandler<CreateWatchListCommand, int>
    {
        private readonly IWatchListService _watchListService;
        private readonly IMapper _mapper;

        public CreateWatchListCommandHandler(IWatchListService watchListService, IMapper mapper)
        {
            _watchListService = watchListService;
            _mapper = mapper;
        }

        public async override Task<int> Handle(CreateWatchListCommand command, CancellationToken cancellationToken)
        {
            var watchList = _mapper.Map<WatchList>(command);
            return await _watchListService.CreateWatchList(watchList);
        }
    }
}
