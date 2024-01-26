using Microsoft.EntityFrameworkCore;
using Todo.EFCore.Context;

namespace Todo.EFCore.Repositories.Common
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {

        private DbSet<T> _entities = null!;
        private bool _isDisposed = false;

        public ToDoAppDbContext Context { get; set; }

        public RepositoryBase(ToDoAppDbContext todoAppContext)
        {
            Context = todoAppContext;
            _isDisposed = false;
        }
        protected virtual DbSet<T> Entities
        {
            get { return _entities ?? (_entities = Context.Set<T>()); }
        }

        public async Task<T> GetByIdAsync(uint id)
        {
            T? entry = await Entities.FindAsync(id);
            if (entry is null)
            {
                throw new NullReferenceException($"{typeof(T)} is null.");
            }
            return entry;
        }

        public async Task InsertAsync(T entity)
        {
            Entities.Add(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("Entity is null"); // Should I throw exception here?
            }

            Context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("Entity is null");  // Should I throw exception here?
            }
            Entities.Remove(entity);
            await SaveAsync();
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            if (Context is not null)
            {
               Context.Dispose();
            }
            _isDisposed = true;
        }


    }
}
