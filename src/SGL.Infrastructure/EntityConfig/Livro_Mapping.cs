using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGL.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGL.Infrastructure.EntityConfig
{
    public class Livro_Mapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(c => c.LivroId);

            builder
                .HasMany(c => c.Links)
                .WithOne(c => c.Livro)
                .HasForeignKey(c => c.LivroId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Titulo)
               .HasColumnType("varchar(250)")
               .IsRequired();

            builder.Property(e => e.Descricao)
               .HasColumnType("varchar(1000)")
               .IsRequired();

            builder.Property(e => e.Sinopse)
               .HasColumnType("varchar(500)")
               .IsRequired();

            builder.Property(e => e.Capa)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(e => e.DataPublicacao)
                .IsRequired();

            builder.Property(e => e.Paginas)
               .IsRequired();
        }
    }
}
