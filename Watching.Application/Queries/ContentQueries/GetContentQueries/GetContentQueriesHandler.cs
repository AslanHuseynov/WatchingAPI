using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.ContentQueries.GetContentQueries
{
    public class GetContentQueriesHandler : IQueryHandler<GetContentQueries, List<Content>>
    {
        private readonly IContentService _contentService;

        public GetContentQueriesHandler(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task<List<Content>> Handle(GetContentQueries request, CancellationToken cancellationToken)
        {
            return await _contentService.GetAllEntity();
        }
    }
}
