using Watching.Application.Commands;
using Watching.Model.Models;

namespace Watching.Application.Dtos.WatchListDto
{
    public class AddToWatchListCommand : BaseCommand<Content2WatchList>
    {
        public int ContenetId { get; set; }
        public int UserId { get; set; }
    }
}
