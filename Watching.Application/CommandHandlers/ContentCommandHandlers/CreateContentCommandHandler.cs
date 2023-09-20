using AutoMapper;
using Watching.Application.Dtos.ContentDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.CommandHandlers.ContentCommandHandlers
{
    public class CreateContentCommandHandler : BaseCommandHandler<CreateContentCommand, Content>
    {
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public CreateContentCommandHandler(IContentService contentService, IMapper mapper)
        {
            _contentService = contentService;
            _mapper = mapper;
        }

        public async override Task<Content> Handle(CreateContentCommand command, CancellationToken cancellationToken)
        {
            var content = _mapper.Map<Content>(command);
            return await _contentService.AddEntity(content);
        }
    }
}
