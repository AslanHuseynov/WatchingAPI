using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.UserQueries.DeleteUserByIdQuery
{
    public class DeleteUserByIdQuery : IQuery<List<User>>
    {
        public int Id { get; set; }
    }
}
