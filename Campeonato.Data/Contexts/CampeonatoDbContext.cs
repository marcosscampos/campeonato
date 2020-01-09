using Campeonato.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Campeonato.Data.Contexts
{
    public class CampeonatoDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Departure> Departures { get; set; }

        public CampeonatoDbContext(DbContextOptions<CampeonatoDbContext> options) : base(options) { }
    }
}
