using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Planets.Domain.Entities;

namespace Planets.Infra.Data.Context
{
    public class MySqlDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        DbSet<UserEntity> Users { get; set; }

        public MySqlDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration.GetConnectionString("MySql");
            optionsBuilder.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 36)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}