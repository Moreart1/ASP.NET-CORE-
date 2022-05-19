using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public interface IUserReposiotry:IUsRepository<User>
    {
    }
    public interface IUsRepository<T> where T : class
    {
        Task Add(T entity);
        Task<IReadOnlyCollection<T>> Get();
        Task Update(T entity);
        Task Delete(UserDeleteModel UserId);
    }
}
