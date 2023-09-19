using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.CategoryQueries.GetCategoryByIdQuery
{
    public class GetCategoryByIdQuery : IQuery<Category>
    {
        public int Id { get; set; }
    }
}
