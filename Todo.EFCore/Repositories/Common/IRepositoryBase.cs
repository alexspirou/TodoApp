namespace Todo.EFCore.Repositories.Common
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}
