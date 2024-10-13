using Microsoft.EntityFrameworkCore;
using DatabaseModels.Entities;

namespace DatabaseContext
{
    public class Context : DbContext
    {
        public DbSet<Curator> Curators { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;database=database;username=postgres;password=negr2003");
        }
    }
}