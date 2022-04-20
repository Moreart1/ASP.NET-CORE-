using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL;
using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDbContext myDbContext;

        public EmployeeRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        public async Task Add(Employee entity)
        {
            entity.IsDelete = false;
            myDbContext.Add(entity);
            await myDbContext.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
           var employee = await myDbContext.Employees.FirstOrDefaultAsync(en =>en.Id == Id);
            employee.IsDelete = true;
            await myDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Employee>> Get()
        {
            var employee = await myDbContext.Employees.ToListAsync();
            return employee;
        }

        public async Task Update(Employee entity)
        {
            var employee = await myDbContext.Employees.FirstOrDefaultAsync(en => en.Id == entity.Id);
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            employee.Company = entity.Company;
            employee.Age = entity.Age;
            employee.IsDelete = entity.IsDelete;
            await myDbContext.SaveChangesAsync();
        }
    }
}
