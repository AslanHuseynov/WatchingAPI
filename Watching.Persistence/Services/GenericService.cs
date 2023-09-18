using Company.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Watching.Application.Interfaces;

namespace Watching.Persistence.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly DataContext _dbContext;
        public GenericService(DataContext context)
        {
            _dbContext = context;
        }

        public async Task<T> AddEntity(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<T>?> DeleteEntity(int id)
        {
            var entities = _dbContext.Set<T>();
            var entity = await entities.FindAsync(id);
            if (entity is null)
                return null;

            entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return await entities.ToListAsync();
        }

        public async Task<List<T>> GetAllEntity()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetEntity(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public virtual async Task<T> UpdateEntity(int id, T req)
        {
            var entity = await GetEntity(id);
            if (entity == null)
                throw new InvalidOperationException("Invalid Operation. Please try again!");
            var entryObject = _dbContext.Entry(entity);
            entryObject.CurrentValues.SetValues(req);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
