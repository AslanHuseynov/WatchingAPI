using Watching.Application.Commands;
using Watching.Model.Models;

namespace Watching.Application.Dtos
{
    public class TagContent : BaseCommand<List<Content2WatchList>>
    {
        public int WatchListId { get; set; }
        public int ContentId { get; set; }
        public bool IsTagged { get; set; }
    }
}
