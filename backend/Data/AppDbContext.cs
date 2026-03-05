using Microsoft.EntityFrameworkCore;

namespace SimLeagueControlCenter.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
    }
}
