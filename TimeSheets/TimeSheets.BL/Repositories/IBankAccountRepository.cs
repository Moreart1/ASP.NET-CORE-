using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public interface IBankAccountRepository:IBankAccount<BankAccount>
    {

    }

    public interface IBankAccount<T> where T : class
    {
        Task Add();
        Task<IReadOnlyCollection<T>> Get();
        Task Operation(T entity);
        Task Close(T entity);
    }
}
