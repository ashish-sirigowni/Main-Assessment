using Main_Assessment.Entity;
using Microsoft.EntityFrameworkCore;

namespace Main_Assessment.Database
{
    public class MyContext:DbContext
    {
        
        private readonly IConfiguration configuration;

        public MyContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Conference>? Conferences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnection"));
        }
    }
}
