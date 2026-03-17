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
        public DbSet<Session> Sessions { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;

        public DbSet<Car> Cars { get; set; } =null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>()
            .HasOne(s => s.League)
            .WithMany()
            .HasForeignKey(s => s.LeagueId);

            modelBuilder.Entity<Event>()
            .ToTable("Events")
            .HasOne(e => e.Season)
            .WithMany()
            .HasForeignKey(e => e.SeasonId);

            modelBuilder.Entity<Session>()
            .HasOne(s => s.Event)
            .WithMany()
            .HasForeignKey(s => s.EventId);

            modelBuilder.Entity<Session>()
            .Property(s => s.Type)
            .HasConversion<string>();

            modelBuilder.Entity<Driver>()
            .ToTable("Drivers");

            modelBuilder.Entity<Team>()
            .ToTable("Teams");

            modelBuilder.Entity<Car>()
            .ToTable("Cars");

            base.OnModelCreating(modelBuilder);
        }
    }
}
