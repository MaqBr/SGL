using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SGL.ApplicationCore.Entity;
using SGL.Infrastructure.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGL.Infrastructure.Data
{
    public class SGLContext : DbContext
    {
        public SGLContext(DbContextOptions<SGLContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Livro_Mapping());
            modelBuilder.ApplyConfiguration(new Editora_Mapping());
            modelBuilder.ApplyConfiguration(new Autor_Mapping());
            modelBuilder.ApplyConfiguration(new Genero_Mapping());
            modelBuilder.ApplyConfiguration(new Link_Mapping());
        }

    }
}
