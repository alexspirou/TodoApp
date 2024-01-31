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

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            T? entry = await Entities.FindAsync(id, cancellationToken);
            if (entry is null)
            {
                throw new NullReferenceException($"{typeof(T)} is null.");
            }
            return entry;
        }

        public async Task InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            Entities.Add(entity);
            await SaveAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("Entity is null"); // Should I throw exception here?
            }

            Context.Entry(entity).State = EntityState.Modified;
            await SaveAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("Entity is null");  // Should I throw exception here?
            }
            Entities.Remove(entity);
            await SaveAsync(cancellationToken);
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
