using Watching.Model.Models;

namespace Watching.Application.Interfaces
{
    public interface IContentService : IGenericService<Content>
    {
        Task<Content?> SearchWithName(string name);
    }
}
