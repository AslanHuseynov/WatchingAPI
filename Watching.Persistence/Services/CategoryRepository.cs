using Company.Persistence.DB;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Persistence.Services
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext db) : base(db)
        {
        }
    }
}
