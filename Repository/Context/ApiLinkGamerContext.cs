using Data.Extensions;
using Data.Mappings;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApiLinkGamerContext : DbContext
    {
        public ApiLinkGamerContext(DbContextOptions<ApiLinkGamerContext> option) : base(option) { }

        #region DbSet
        public DbSet<User> User { get; set; }
        #endregion
        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ApiLinkGamerConnection"));
        }

        public ApiLinkGamerContext CreateDbContext(string[] args)
        {
            var optionbuilder = new DbContextOptionsBuilder<ApiLinkGamerContext>();
            optionbuilder.EnableSensitiveDataLogging(false);
            return new ApiLinkGamerContext(optionbuilder.Options);
        }

    }
}
