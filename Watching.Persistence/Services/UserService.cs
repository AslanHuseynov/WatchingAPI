using Company.Persistence.DB;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Persistence.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(DataContext db) : base(db)
        {
        }
    }
}
