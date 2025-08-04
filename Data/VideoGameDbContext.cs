using Microsoft.EntityFrameworkCore;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "FC25",
                    Platform = "Xbox 360",
                    Developer = "EA Sports",
                    Publisher = "Sony Interactive Entertainment"
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "Call of Duty",
                    Platform = "PS5",
                    Developer = "Activision",
                    Publisher = "Playstation"
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "Cyberpunk 2077",
                    Platform = "PC",
                    Developer = "CD Projekt Red",
                    Publisher = "CD Projekt"
                }
            );

        }
    }
}
