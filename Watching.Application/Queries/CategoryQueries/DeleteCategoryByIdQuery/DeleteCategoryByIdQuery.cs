using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.CategoryQueries.DeleteCategoryByIdQuery
{
    public class DeleteCategoryByIdQuery : IQuery<List<Category>>
    {
        public int Id { get; set; }
    }
}
