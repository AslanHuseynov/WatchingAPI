using AutoMapper;
using Watching.Application.Dtos.CategoryDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.CommandHandlers.CategoryCommandHandlers
{
    public class UpdateCategoryCommandHandler : BaseCommandHandler<UpdateCategoryCommand, Category>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async override Task<Category> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(command);
            return await _categoryService.UpdateEntity(command.Id, category);
        }
    }
}
