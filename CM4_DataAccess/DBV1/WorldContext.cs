using CM4_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CM4_DataAccess.DBV1
{
    internal class WorldContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Character> Characters { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Species> Species { get; set; }

        public WorldContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
