using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGL.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGL.Infrastructure.EntityConfig
{
    public class Link_Mapping : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.ToTable("Link");
            builder.HasKey(c => c.LinkId);

            builder.Property(e => e.Url)
               .HasColumnType("varchar(250)")
               .IsRequired();

            builder.Property(e => e.Descricao)
               .HasColumnType("varchar(500)")
               .IsRequired();

            builder.Property(e => e.Icone)
               .HasColumnType("varchar(100)")
               .IsRequired();

        }
    }
}
