using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<T>(this ModelBuilder modelBuilder, BaseEntityMapping<T> configuration) where T : BaseEntity
        {
            configuration.Map(modelBuilder.Entity<T>());
        }
    }
}
