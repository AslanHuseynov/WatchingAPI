using AutoMapper;
using Watching.Application.Dtos.ContentDto;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.CommandHandlers.ContentCommandHandlers
{
    public class UpdateContentCommandHandler : BaseCommandHandler<UpdateContentCommand, Content>
    {
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public UpdateContentCommandHandler(IContentService contentService, IMapper mapper)
        {
            _contentService = contentService;
            _mapper = mapper;
        }

        public async override Task<Content> Handle(UpdateContentCommand command, CancellationToken cancellationToken)
        {
            var name = _mapper.Map<Content>(command);
            return await _contentService.UpdateEntity(command.Id, name);
        }
    }
}
