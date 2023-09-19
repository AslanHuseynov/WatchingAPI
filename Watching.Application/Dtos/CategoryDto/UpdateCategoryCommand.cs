using Watching.Application.Commands;
using Watching.Model.Models;

namespace Watching.Application.Dtos.CategoryDto
{
    public class UpdateCategoryCommand :BaseCommand<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
