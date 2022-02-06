using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AMedia.Data
{
    public partial class TestCrudContext : DbContext
    {
        public TestCrudContext()
        {
        }

        public TestCrudContext(DbContextOptions<TestCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tGenero> tGenero { get; set; }
        public virtual DbSet<tGeneroPelicula> tGeneroPelicula { get; set; }
        public virtual DbSet<tPelicula> tPelicula { get; set; }
        public virtual DbSet<tRol> tRol { get; set; }
        public virtual DbSet<tUsers> tUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=TestCrud;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tGenero>(entity =>
            {
                entity.HasKey(e => e.cod_genero)
                    .HasName("PK__tGenero__0DACB9D51FA6D9C7");

                entity.Property(e => e.txt_desc).IsUnicode(false);
            });

            modelBuilder.Entity<tGeneroPelicula>(entity =>
            {
                entity.HasKey(e => new { e.cod_pelicula, e.cod_genero })
                    .HasName("PK__tGeneroP__6285A595A5FEB9D0");

                entity.HasOne(d => d.cod_generoNavigation)
                    .WithMany(p => p.tGeneroPelicula)
                    .HasForeignKey(d => d.cod_genero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pelicula_genero");

                entity.HasOne(d => d.cod_peliculaNavigation)
                    .WithMany(p => p.tGeneroPelicula)
                    .HasForeignKey(d => d.cod_pelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_genero_pelicula");
            });

            modelBuilder.Entity<tPelicula>(entity =>
            {
                entity.HasKey(e => e.cod_pelicula)
                    .HasName("PK__tPelicul__225F6E08182F0304");

                entity.Property(e => e.txt_desc).IsUnicode(false);
            });

            modelBuilder.Entity<tRol>(entity =>
            {
                entity.HasKey(e => e.cod_rol)
                    .HasName("PK__tRol__F13B121197B01D30");

                entity.Property(e => e.txt_desc).IsUnicode(false);
            });

            modelBuilder.Entity<tUsers>(entity =>
            {
                entity.HasKey(e => e.cod_usuario)
                    .HasName("PK__tUsers__EA3C9B1A6B3E40AB");

                entity.Property(e => e.nro_doc).IsUnicode(false);

                entity.Property(e => e.txt_apellido).IsUnicode(false);

                entity.Property(e => e.txt_nombre).IsUnicode(false);

                entity.Property(e => e.txt_password).IsUnicode(false);

                entity.Property(e => e.txt_user).IsUnicode(false);

                entity.HasOne(d => d.cod_rolNavigation)
                    .WithMany(p => p.tUsers)
                    .HasForeignKey(d => d.cod_rol)
                    .HasConstraintName("fk_user_rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
