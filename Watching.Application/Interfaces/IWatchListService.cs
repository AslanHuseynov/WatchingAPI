using Watching.Application.Dtos;
using Watching.Model.Models;

namespace Watching.Application.Interfaces
{
    public interface IWatchListService
    {
        Task<List<WatchList>> GetWatchListAsync();
        Task<List<Content2WatchList>> GetContent2WatchListsAsync();
        Task<Content2WatchList> AddToWatchList(int watchListId, int contentId);
        Task<int> CreateWatchList(WatchList watchList);
        Task<List<Content>> GetWithUser(int userId);
        Task<Content2WatchList> UpdateIsTaggedAsync(TagContent tagContent);
        Task DeleteEntity(int userId);
    }
}
