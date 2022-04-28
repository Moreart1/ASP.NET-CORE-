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

        public async Task Delete(EmployeeDeleteModel employeeId)
        {
            var employee = await myDbContext.Employees.Where(en => en.Id == employeeId.Id)
                  .SingleOrDefaultAsync();
            myDbContext.Persons.Remove(employee);
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
