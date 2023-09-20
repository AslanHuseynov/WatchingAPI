using Watching.Application.Commands;
using Watching.Application.Dtos.ContentDto;
using Watching.Model.Models;

namespace Watching.Application.Dtos.ContentDto
{
    public class UpdateContentCommand : BaseCommand<Content>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
