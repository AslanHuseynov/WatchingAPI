using Watching.Application.Commands;
using Watching.Model.Models;

namespace Watching.Application.Dtos.CategoryDto
{
    public class CreateCategoryCommand : BaseCommand<Category>
    {
        public string Name { get; set; }
    }
}
