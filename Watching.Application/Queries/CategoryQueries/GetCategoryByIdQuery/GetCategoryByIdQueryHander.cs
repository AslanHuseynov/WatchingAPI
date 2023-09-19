using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.CategoryQueries.GetCategoryByIdQuery
{
    public class GetCategoryByIdQueryHander : IQueryHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryByIdQueryHander(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetEntity(request.Id);
        }
    }
}
