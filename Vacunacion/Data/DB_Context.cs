using Microsoft.EntityFrameworkCore;
using Vacunacion.Models;

namespace Vacunacion.Data
{
    public class DB_Context:DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Brigade> Brigade { get; set; }
        public DbSet<RegisterVaccine>  RegisterVaccine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Campaign>().ToTable("Campaign");
            modelBuilder.Entity<Brigade>().ToTable("Brigade");
            modelBuilder.Entity<RegisterVaccine>().ToTable("RegisterVaccine");
        }

        
    }

}
