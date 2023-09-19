using AutoMapper;
using Watching.Application.Dtos.CategoryDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.CommandHandlers.CategoryCommandHandlers
{
    public class CreateCategoryCommandHandler : BaseCommandHandler<CreateCategoryCommand, Category>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async override Task<Category> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(command);
            return await _categoryService.AddEntity(category);
        }
    }
}
