using Watching.Model.Models;

namespace Watching.Application.Interfaces
{
    public interface IWatchingNameRepository : IGenericRepository<WatchingName>
    {
        Task<WatchingName?> SearchWithName(string name);
    }
}
