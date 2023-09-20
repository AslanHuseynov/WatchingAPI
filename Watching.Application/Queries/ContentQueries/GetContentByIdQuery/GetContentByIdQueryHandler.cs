using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.ContentQueries.GetContentByIdQuery
{
    public class GetContentByIdQueryHandler : IQueryHandler<GetContentByIdQuery, Content>
    {
        private readonly IContentService _contentService;

        public GetContentByIdQueryHandler(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task<Content?> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _contentService.GetEntity(request.Id);
        }
    }
}
