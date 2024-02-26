using Microsoft.EntityFrameworkCore;
using RegistrationApp.Domein.Entities.Models;

namespace RegistrationApp.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Login> Logins { get; set; }
    }
}
