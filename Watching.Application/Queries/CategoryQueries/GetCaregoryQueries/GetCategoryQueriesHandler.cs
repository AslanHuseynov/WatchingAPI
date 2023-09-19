using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.CategoryQueries.GetCaregoryQueries
{
    public class GetCategoryQueriesHandler : IQueryHandler<GetCategoryQueries, List<Category>>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryQueriesHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<Category>> Handle(GetCategoryQueries request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllEntity();
        }
    }
}
