using Microsoft.EntityFrameworkCore;
using SimleagueControlCenter.Models;
using SimLeagueControlCenter.Models;

namespace SimLeagueControlCenter.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<League> Leagues { get; set; } = null!;
        public DbSet<Season> Seasons { get; set; } = null!;

        public DbSet<Event> Events { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>()
            .HasOne(s => s.League)
            .WithMany()
            .HasForeignKey(s => s.LeagueId);

            modelBuilder.Entity<Event>()
            .HasOne(e => e.Season)
            .WithMany()
            .HasForeignKey(e => e.SeasonId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
