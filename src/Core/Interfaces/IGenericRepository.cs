namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task UpdateAsync(Guid id, T entity);
        Task DeleteAsync(Guid id);
    }
}