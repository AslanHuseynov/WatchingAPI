using Company.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Persistence.Services
{
    public class WatchingNameRepository : GenericRepository<WatchingName>, IWatchingNameRepository
    {
        public WatchingNameRepository(DataContext db) : base(db)
        {
        }

        public async Task<WatchingName?> SearchWithName(string name)
        {
            var hero = await _dbContext.WatchingNames.FirstOrDefaultAsync(x => x.Name == name);
            if (hero is null)
                return null;

            return hero;
        }
    }
}
