using dal.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace dal
{
    public class MainDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; } = default!;
        public DbSet<GameType> GameTypes { get; set; } = default!;

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameType>().HasData(
                new GameType
                {
                    Id = 1,
                    Description = "Type A"
                },
                new GameType
                {
                    Id = 2,
                    Description = "Type B"
                });
            SaveChangesAsync();

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "Game 1",
                    Description = "A Game",
                    GameTypeId = 1
                },
                new Game
                {
                    Id = 2,
                    Name = "Game 2",
                    Description = "Another Game",
                    GameTypeId = 2
                });
            SaveChangesAsync();
        }
    }


}
