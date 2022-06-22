using GeekComics.Domain.Models;
using GeekComics.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GeekComics.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        /** Можно было бы создать просто контекст, но лучше фабрику, чтобы куча потоков не использовала один контекст */
        private readonly GeekComicsDbContextFactory _contextFactory;

        public GenericDataService(GeekComicsDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using GeekComicsDbContext context = _contextFactory.CreateDbContext();
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdResult.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            using GeekComicsDbContext context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<T> Get(int id)
        {
            using GeekComicsDbContext context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using GeekComicsDbContext context = _contextFactory.CreateDbContext();
            IEnumerable<T> enities = await context.Set<T>().ToListAsync();
            return enities;
        }

        public async Task<T> Update(int id, T entity)
        {
            using GeekComicsDbContext context = _contextFactory.CreateDbContext();
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
