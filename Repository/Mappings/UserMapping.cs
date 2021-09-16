using Data.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder
                .Property(x => x.Email)
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(x => x.Nome)
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(x => x.Sobrenome)
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(x => x.Role)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.Ativo)
                .HasColumnType("bit");

            base.Map(builder);
        }
    }
}
