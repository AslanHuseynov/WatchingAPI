using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.ContentQueries.DeleteContentByIdQuery
{
    public class DeleteContentByIdQueryHandler : IQueryHandler<DeleteContentByIdQuery, List<Content>>
    {
        private readonly IContentService _contentService;

        public DeleteContentByIdQueryHandler(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task<List<Content>?> Handle(DeleteContentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _contentService.DeleteEntity(request.Id);
        }
    }
}
