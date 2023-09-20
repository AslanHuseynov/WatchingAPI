using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.ContentQueries.DeleteContentByIdQuery
{
    public class DeleteContentByIdQuery : IQuery<List<Content>>
    {
        public int Id { get; set; }
    }
}
