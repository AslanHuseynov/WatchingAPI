using Company.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Watching.Application.Dtos;
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

        public async Task<int> CreateWatchList(WatchList watchList)
        {
            _dbContext.WatchLists.Add(watchList);
            await _dbContext.SaveChangesAsync();
            return watchList.Id;
        }

        public async Task<Content2WatchList> AddToWatchList(int contentId, int userId)
        {
            var content = await _dbContext.Contents.SingleOrDefaultAsync(x => x.Id == contentId) ??
                throw new InvalidOperationException($"Couldn't find watchingitem! {contentId}");

            var watchList = await _dbContext.WatchLists.SingleOrDefaultAsync(x => x.UserId == userId) ??
                throw new InvalidOperationException($"Couldn't find watchList! userId:{userId}");


            var content2WatchList = new Content2WatchList() { ContentId = contentId, WatchListId = watchList.Id };
            await _dbContext.Content2WatchLists.AddAsync(content2WatchList);
            await _dbContext.SaveChangesAsync();

            return content2WatchList;
        }

        public async Task<List<Content>> GetWithUser(int userId)
        {
            var watchList = await _dbContext.WatchLists.SingleOrDefaultAsync(u => u.UserId == userId);
            if (watchList == null)
                throw new InvalidOperationException($"Couldn't find watchList! userId:{userId}");
            var contents = _dbContext.Content2WatchLists.Where(x => x.WatchListId == watchList.Id)
                .Select(x => x.Content)
                .ToList();
            return contents;
        }

        public async Task<Content2WatchList> UpdateIsTaggedAsync(TagContent tagContent)
        {
            var watchList = await _dbContext.WatchLists.FindAsync(tagContent.WatchListId) ?? 
                throw new InvalidOperationException($"Couldn't find watchList : {tagContent.WatchListId}");

            var desiredMiddleObject = await _dbContext.Content2WatchLists.SingleOrDefaultAsync(x =>
            x.WatchListId == watchList.Id && x.ContentId == tagContent.ContentId);

            if ( desiredMiddleObject == null)
                throw new InvalidOperationException("Couldn't find middle object");


            desiredMiddleObject.IsTagged = tagContent.IsTagged;

            await _dbContext.SaveChangesAsync();

            return desiredMiddleObject;
        }

        public async Task DeleteEntity(int userId)
        {
            var watchList = await _dbContext.WatchLists.SingleOrDefaultAsync(x => x.UserId == userId);

            if (watchList == null)
                throw new InvalidOperationException($"Couldn't find watchlist! userId:{userId}");

            var content2WatchLists = _dbContext.Content2WatchLists.Where(x => x.WatchListId == watchList.Id);
            _dbContext.Content2WatchLists.RemoveRange(content2WatchLists);

            //პოტენტციური გამოსავალი
            //await _dbContext.SaveChangesAsync();

            _dbContext.WatchLists.Remove(watchList);
            await _dbContext.SaveChangesAsync();

        }
    }
}
