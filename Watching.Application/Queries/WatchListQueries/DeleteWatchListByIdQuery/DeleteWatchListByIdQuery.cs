using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.WatchListQueries.DeleteWatchListByIdQuery
{
    public class DeleteWatchListByIdQuery : IQuery<List<WatchList>>
    {
        public int Id { get; set; }
    }
}
