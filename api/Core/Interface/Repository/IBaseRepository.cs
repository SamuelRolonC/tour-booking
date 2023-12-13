using Core.Entity;

namespace Core.Interface.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<(bool, string)> RemoveAsync(int id);
        Task<T> GetByIdAsync(int id);
    }
}
