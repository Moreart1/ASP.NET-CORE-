using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL;
using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyDbContext myDbContext;

        public PersonRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        public async Task Add(Person entity)
        {
            entity.IsDelete = false;
            myDbContext.Add(entity);
            await myDbContext.SaveChangesAsync();
        }

        public async Task Delete(int PersonId)
        {
            var person = await myDbContext.Persons.FirstOrDefaultAsync(en => en.Id == PersonId);
                person.IsDelete = true;
            await myDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Person>> Get()
        {
            var person = await myDbContext.Persons.ToListAsync();
            return person;
        }

        public async Task Update(Person entity)
        {
            var person = await myDbContext.Persons.FirstOrDefaultAsync(en => en.Id == entity.Id);
            person.FirstName = entity.FirstName;
            person.LastName = entity.LastName;
            person.Email = entity.Email;
            person.Company = entity.Company;
            person.Age = entity.Age;
            person.IsDelete = entity.IsDelete;
            await myDbContext.SaveChangesAsync();
        }
    }
}
