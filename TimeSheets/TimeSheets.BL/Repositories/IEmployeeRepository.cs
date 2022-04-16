using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public interface IEmployeeRepository: IEmRepository<Employee>
    {
    }
    public interface IEmRepository<T> where T : class
    {
        Task Add(T entity);
        Task<IReadOnlyCollection<T>> Get();
        Task Update(T entity);
        Task Delete(int Id);
    }
}
