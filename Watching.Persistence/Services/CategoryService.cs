using Company.Persistence.DB;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Persistence.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(DataContext db) : base(db)
        {
        }
    }
}
