using Watching.Application.Commands;
using Watching.Model.Models;

namespace Watching.Application.Dtos.ContentDto
{
    public class CreateContentCommand : BaseCommand<Content>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
