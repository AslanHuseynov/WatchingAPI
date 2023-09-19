using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.CategoryQueries.DeleteCategoryByIdQuery
{
    public class DeleteCategoryByIdQueryHandler : IQueryHandler<DeleteCategoryByIdQuery, List<Category>>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryByIdQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<Category>?> Handle(DeleteCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoryService.DeleteEntity(request.Id);
        }
    }
}
