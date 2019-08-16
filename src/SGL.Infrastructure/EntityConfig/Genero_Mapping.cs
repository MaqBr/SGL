using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGL.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGL.Infrastructure.EntityConfig
{
    public class Genero_Mapping : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Genero");
            builder.HasKey(c => c.GeneroId);

            builder
                .HasMany(c => c.Livros)
                .WithOne(c => c.Genero)
                .HasForeignKey(c => c.GeneroId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Descricao)
               .HasColumnType("varchar(200)")
               .IsRequired();

        }
    }
}
