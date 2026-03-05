using Microsoft.EntityFrameworkCore;
using SimLeagueControlCenter.Models;

namespace SimLeagueControlCenter.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<League> Leagues { get; set; } = null!;
        public DbSet<Season> Seasons { get; set; } = null!;
    }
}
