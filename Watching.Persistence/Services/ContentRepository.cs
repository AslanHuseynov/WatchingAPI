using Company.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Persistence.Services
{
    public class ContentRepository : GenericRepository<Content>, IContentRepository
    {
        public ContentRepository(DataContext db) : base(db)
        { 
        }

        public async Task<Content?> SearchWithName(string name) =>
            await _dbContext.Contents.FirstOrDefaultAsync(x => x.Name == name);

        public override async Task<List<Content>?> DeleteEntity(int id)
        {
            var content2WatchLists = _dbContext.Content2WatchLists.Where(x => x.ContentId == id);
            _dbContext.Content2WatchLists.RemoveRange(content2WatchLists);

            //პოტენტციური გამოსავალი
            //await _dbContext.SaveChangesAsync();

            var contents =  await base.DeleteEntity(id);
            return contents;
        }
    }
}
