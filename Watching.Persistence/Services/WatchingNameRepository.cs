using Company.Persistence.DB;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Persistence.Services
{
    public class WatchingNameRepository : GenericRepository<WatchingName>, IWatchingNameRepository
    {
        public WatchingNameRepository(DataContext db) : base(db)
        {
        }
    }
}
