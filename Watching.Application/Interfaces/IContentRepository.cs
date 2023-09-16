using Watching.Model.Models;

namespace Watching.Application.Interfaces
{
    public interface IContentRepository : IGenericRepository<Content>
    {
        Task<Content?> SearchWithName(string name);
    }
}
