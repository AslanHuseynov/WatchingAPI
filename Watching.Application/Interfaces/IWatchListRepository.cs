using Watching.Model.Models;

namespace Watching.Application.Interfaces
{
    public interface IWatchListRepository
    {
        Task<List<WatchList>> GetWatchListAsync();
        Task<List<WatchList>> AddToWatchList(WatchList list);
        Task<List<WatchList>> GetWithUser(int userId);
        Task UpdateIsCheckedAsync(int id, bool isChecked);
    }
}
