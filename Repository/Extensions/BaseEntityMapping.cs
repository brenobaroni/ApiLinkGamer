using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions
{
    public class BaseEntityMapping<T> where T : BaseEntity
    {
        public virtual void Map(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.DataCriacao)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder
                .Property(x => x.DataAtualizacao)
                .HasColumnType("datetime")
                .IsRequired(false);

            builder
                .Property(x => x.DataExclusao)
                .HasColumnType("datetime")
                .IsRequired(false);
        }

    }
}
