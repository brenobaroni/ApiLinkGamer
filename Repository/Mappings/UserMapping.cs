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
    public class UserMapping : BaseEntityMapping<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(x => x.Email)
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(x => x.Role)
                .HasColumnType("int")
                .IsRequired(false);

            builder
                .Property(x => x.Ativo)
                .HasColumnType("bit")
                .IsRequired();

            base.Map(builder);
        }
    }
}
