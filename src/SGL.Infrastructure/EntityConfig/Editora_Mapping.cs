using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGL.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGL.Infrastructure.EntityConfig
{
    public class Editora_Mapping : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder.ToTable("Editora");
            builder.HasKey(c => c.EditoraId);

            builder
                .HasMany(c => c.Livros)
                .WithOne(c => c.Editora)
                .HasForeignKey(c => c.EditoraId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Descricao)
               .HasColumnType("varchar(1000)")
               .IsRequired();

            builder.Property(e => e.Email)
               .HasColumnType("varchar(150)");

        }
    }
}
