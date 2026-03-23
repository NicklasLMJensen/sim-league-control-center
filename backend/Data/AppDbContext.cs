using Microsoft.EntityFrameworkCore;
using SimleagueControlCenter.Models;
using SimLeagueControlcenter.Models;
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
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Entry> Entries { get; set; } = null!;
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

            modelBuilder.Entity<Entry>()
            .ToTable("Entries")
            .HasOne(e => e.Season)
            .WithMany()
            .HasForeignKey(e => e.SeasonId);

            modelBuilder.Entity<Entry>()
            .HasOne(e => e.Driver)
            .WithMany()
            .HasForeignKey(e => e.DriverId);

            modelBuilder.Entity<Entry>()
            .HasOne(e => e.Team)
            .WithMany()
            .HasForeignKey(e => e.TeamId);

            modelBuilder.Entity<Entry>()
            .HasOne(e => e.Car)
            .WithMany()
            .HasForeignKey(e => e.CarId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
