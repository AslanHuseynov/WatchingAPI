using Company.Persistence.DB;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Persistence.Services
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext db) : base(db)
        {
        }
    }
}
