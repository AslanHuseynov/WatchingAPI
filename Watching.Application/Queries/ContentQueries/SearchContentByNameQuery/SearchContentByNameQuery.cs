using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.ContentQueries.SearchContentByNameQuery
{
    public class SearchContentByNameQuery : IQuery<Content>
    {
        public string Name { get; set; }
    }
}
