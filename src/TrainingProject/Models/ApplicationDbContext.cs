using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;

namespace TrainingProject.Models
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }



        public ApplicationDbContext()
            : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");

        }

        public IConfigurationRoot Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            Configuration = configuration.Build();
            optionsBuilder.UseSqlServer(Configuration["Data:ConnectionString"]);
        }
    }
}