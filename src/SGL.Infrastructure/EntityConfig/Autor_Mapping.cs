using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGL.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGL.Infrastructure.EntityConfig
{
    public class Autor_Mapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(c => c.AutorId);

            builder
                .HasMany(c => c.Livros)
                .WithOne(c => c.Autor)
                .HasForeignKey(c => c.AutorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Nome)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(e => e.Email)
               .HasColumnType("varchar(150)");

        }
    }
}
