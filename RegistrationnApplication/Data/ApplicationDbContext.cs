using Microsoft.EntityFrameworkCore;
using RegistrationnApplication.Models;

namespace RegistrationnApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
            
        }
        public DbSet<Registration> registrations { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<Gender> Genders{ get; set; }
    }
}
