using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<T>(this ModelBuilder modelBuilder, EntityTypeConfiguration<T> configuration) where T : BaseEntity
        {
            configuration.Map(modelBuilder.Entity<T>());
        }
    }
}
