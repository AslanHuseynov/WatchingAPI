using System.Xml.Linq;
using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.ContentQueries.SearchContentByNameQuery
{
    public class SearchContentByNameQueryHandler : IQueryHandler<SearchContentByNameQuery, Content>
    {
        private readonly IContentService _contentService;

        public SearchContentByNameQueryHandler(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task<Content?> Handle(SearchContentByNameQuery request, CancellationToken cancellationToken)
        {
            return await _contentService.SearchWithName(request.Name);
        }
    }
}
