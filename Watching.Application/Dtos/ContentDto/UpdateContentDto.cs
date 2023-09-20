using Watching.Application.Dtos.ContentDto;

namespace Watching.Application.Dtos.ContentDto
{
    public class UpdateContentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
