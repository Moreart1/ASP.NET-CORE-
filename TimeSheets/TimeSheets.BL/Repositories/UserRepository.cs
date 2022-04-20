using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL;
using TimeSheets.DAL.Models;

namespace TimeSheets.BL.Repositories
{
    public class UserRepository : IUserReposiotry
    {
        private readonly MyDbContext myDbContext;

        public UserRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public async Task Add(User entity)
        {
            entity.IsDelete = false;
            myDbContext.Users.Add(entity);
            await myDbContext.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var User = myDbContext.Users.FirstOrDefault(x => x.Id == Id);
            User.IsDelete = true;
            await myDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<User>> Get()
        {
            var User = await myDbContext.Users.ToListAsync();
            return User;
        }

        public async Task Update(User entity)
        {
            var User = await myDbContext.Users.FirstOrDefaultAsync(x =>x.Id == entity.Id);
            User.FirstName = entity.FirstName;
            User.LastName = entity.LastName;
            User.Email = entity.Email;
            User.Company = entity.Company;
            User.Age = entity.Age;
            User.IsDelete = entity.IsDelete;
            await myDbContext.SaveChangesAsync();
        }
    }
}
