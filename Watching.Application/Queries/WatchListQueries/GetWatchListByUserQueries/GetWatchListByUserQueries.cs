using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.WatchListQueries.GetWatchListByUserQueries
{
    public class GetWatchListByUserQueries : IQuery<List<Content>>
    {
        public int UserId { get; set; }
    }
}
