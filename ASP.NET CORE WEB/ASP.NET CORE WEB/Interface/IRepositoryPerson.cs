using ASP.NET_CORE_WEB.Models;

namespace ASP.NET_CORE_WEB.Repository
{
    public interface IRepositoryPerson<T>
    {
        Task<T> FindByIdAsync(int id);
        Task<IQueryable<T>> FindByNameAsync(Pagination pagination, string name);
        Task<IQueryable<T>> FindAllAsync(Pagination pagination);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
