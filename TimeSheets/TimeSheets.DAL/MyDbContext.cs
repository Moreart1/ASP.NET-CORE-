using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<BankAccount>();
        }
    }
}
