using Watching.Application.Commands;

namespace Watching.Application.Dtos.WatchListDto
{
    public class CreateWatchListCommand : BaseCommand<int>
    {
        public int UserId { get; set; }
    }
}
