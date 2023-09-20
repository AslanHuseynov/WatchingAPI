using Watching.Application.Interfaces;
using Watching.Model.Models;

namespace Watching.Application.Queries.UserQueries.GetUserByIdQuery
{
    public class GetUserByIdQuery : IQuery<User>
    {
        public int Id { get; set; }
    }
}
