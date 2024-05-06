using Microsoft.EntityFrameworkCore;
using Planets.Data.Entities;

namespace Planets.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<UserModel> Users { get; set; }
        

        public AppDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("MySql"), new MySqlServerVersion(new Version(8, 0, 36)));
        }
    }
}