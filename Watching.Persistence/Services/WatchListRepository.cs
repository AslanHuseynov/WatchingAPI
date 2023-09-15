using Company.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Persistence.Services
{
    public class WatchListRepository : IWatchListRepository
    {
        private readonly DataContext _dbContext;

        public WatchListRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WatchList>> GetWatchListAsync()
        {
            return await _dbContext.WatchLists.ToListAsync();
        }

        public async Task<List<WatchList>> AddToWatchList(WatchList list)
        {
            _dbContext.WatchLists.Add(list);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.WatchLists.ToListAsync();
        }

        public async Task<List<WatchList>> GetWithUser(int userId)
        {
            var list = await _dbContext.WatchLists.Where(u => u.UserId == userId).ToListAsync();
            return list;
        }

        public async Task UpdateIsCheckedAsync(int id, bool isChecked)
        {
            var watchListItem = await _dbContext.WatchLists.FindAsync(id);

            if (watchListItem == null)
            {
                throw new Exception();
            }

            watchListItem.IsChecked = isChecked;
            await _dbContext.SaveChangesAsync();
        }
    }
}
