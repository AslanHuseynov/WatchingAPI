namespace Watching.Application.Interfaces
{
    public interface IGenericService<T>
    {
        Task<List<T>> GetAllEntity();
        Task<T?> GetEntity(int id);
        Task<T> AddEntity(T entity);
        Task<T> UpdateEntity(int id, T req);
        Task<List<T>?> DeleteEntity(int id);
    }
}
