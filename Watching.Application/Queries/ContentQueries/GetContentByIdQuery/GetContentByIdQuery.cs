using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.ContentQueries.GetContentByIdQuery
{
    public class GetContentByIdQuery : IQuery<Content>
    {
        public int Id { get; set; }
    }
}
