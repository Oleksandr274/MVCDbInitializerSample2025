using Microsoft.EntityFrameworkCore;

namespace Week1Lab12026.Models
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext()
            : base()
        {
            //Database.EnsureCreated(); // Automatic migrations
        }

        public UserContext(DbContextOptions options): base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }


    }
}
