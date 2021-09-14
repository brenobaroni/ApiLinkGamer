using Data.Extensions;
using Data.Mappings;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApiLinkGamerContext : DbContext
    {

        public ApiLinkGamerContext(DbContextOptions<ApiLinkGamerContext> dbContextOptions) : base(dbContextOptions) { }

        #region DbSet
        DbSet<User> Users { get; set; }
        #endregion


        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration<User>(new UserMapping());
        }
        #endregion
    }
}
