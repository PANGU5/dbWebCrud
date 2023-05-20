using dbWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace dbWeb.Data
{
    public class DatabaseAPIContext: DbContext
    {
        public DatabaseAPIContext(DbContextOptions<DatabaseAPIContext> options) : base(options) 
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Department>().ToTable("Department");
        }
    }
}
