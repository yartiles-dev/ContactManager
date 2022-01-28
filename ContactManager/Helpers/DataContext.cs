using Microsoft.EntityFrameworkCore;
using ContactManager.Entities;

namespace ContactManager.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                // connect to sql server database
                // options.UseSqlServer(Configuration.GetConnectionString("user_managerContext"));
                
                // connect to mysql server database
                options.UseMySql(Configuration.GetConnectionString("user_managerContext"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.10-mariadb"));
            }
        }

        public virtual DbSet<Contact> Contact { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<UserRole> UserRole { get; set; } = null!;
        public virtual DbSet<Role> Role { get; set; } = null!;
    }
}