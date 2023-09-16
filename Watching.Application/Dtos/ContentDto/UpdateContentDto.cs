using Watching.Application.Dtos.ContentDto;

namespace Watching.Application.Dtos.ContentDto
{
    public class UpdateContentDto : BaseContentDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
    }
}
