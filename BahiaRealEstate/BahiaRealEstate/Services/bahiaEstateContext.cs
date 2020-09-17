using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BahiaRealEstate.Models
{
    public partial class bahiaEstateContext : DbContext
    {
        

        public bahiaEstateContext()
        {
        }

        

        public bahiaEstateContext(DbContextOptions<bahiaEstateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Propiedad> Propiedad { get; set; }
        public virtual DbSet<PropiedadDireccion> PropiedadDireccion { get; set; }
        public virtual DbSet<PropiedadFoto> PropiedadFoto { get; set; }
        public virtual DbSet<PropiedadPrecio> PropiedadPrecio { get; set; }
        public virtual DbSet<Solar> Solar { get; set; }
        public virtual DbSet<SolarDireccion> SolarDireccion { get; set; }
        public virtual DbSet<SolarFoto> SolarFoto { get; set; }
        public virtual DbSet<SolarPrecio> SolarPrecio { get; set; }
        public virtual DbSet<TipoInmueble> TipoInmueble { get; set; }
        public virtual DbSet<TipoMoneda> TipoMoneda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-L2QEUDE\\SQLEXPRESS; Database=bahiaEstate; Trusted_Connection=True;");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Propiedad>(entity =>
            {
                entity.ToTable("propiedad");

                entity.Property(e => e.Id).HasColumnName("id").UseIdentityColumn();

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.AreaGym)
                    .HasColumnName("areaGym")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AreaLavado)
                    .HasColumnName("areaLavado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Caliente)
                    .HasColumnName("caliente")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuartoServicio)
                    .HasColumnName("cuartoServicio")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Cuartos).HasColumnName("cuartos");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Destacado)
                    .HasColumnName("destacado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ducha).HasColumnName("ducha");

                entity.Property(e => e.TipoInmuebleId).HasColumnName("tipoInmuebleID");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoInmueble)
                    .WithMany(p => p.Propiedad)
                    .HasForeignKey(d => d.TipoInmuebleId)
                    .HasConstraintName("propiedadTipo_fk");
            });

            modelBuilder.Entity<PropiedadDireccion>(entity =>
            {
                entity.ToTable("propiedadDireccion");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.IdPropiedad).HasColumnName("idPropiedad");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PropiedadDireccion)
                    .HasForeignKey<PropiedadDireccion>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("propiedadDireccion_fk");
            });

            modelBuilder.Entity<PropiedadFoto>(entity =>
            {
                entity.ToTable("propiedadFoto");

                entity.Property(e => e.Id).HasColumnName("id").UseIdentityColumn();

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .IsUnicode(false);

                entity.Property(e => e.Propiedadid).HasColumnName("propiedadid");

                entity.HasOne(d => d.Propiedad)
                    .WithMany(p => p.PropiedadFoto)
                    .HasForeignKey(d => d.Propiedadid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("propiedadFoto_fk");
            });

            modelBuilder.Entity<PropiedadPrecio>(entity =>
            {
                entity.ToTable("propiedadPrecio");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityColumn()
                    .ValueGeneratedNever();

                entity.Property(e => e.Monedaid).HasColumnName("monedaid");

                entity.Property(e => e.NotaPrecio)
                    .HasColumnName("notaPrecio")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PropiedadPrecio)
                    .HasForeignKey<PropiedadPrecio>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("propiedadPrecio_fk");

                entity.HasOne(d => d.Moneda)
                    .WithMany(p => p.PropiedadPrecio)
                    .HasForeignKey(d => d.Monedaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("propiedadPrecio_moneda_fk");
            });

            modelBuilder.Entity<Solar>(entity =>
            {
                entity.ToTable("solar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Destacado)
                    .HasColumnName("destacado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioMetro)
                    .HasColumnName("precioMetro")
                    .HasColumnType("decimal(13, 2)");

                entity.Property(e => e.TipoInmuebleid).HasColumnName("tipoInmuebleid");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoInmueble)
                    .WithMany(p => p.Solar)
                    .HasForeignKey(d => d.TipoInmuebleid)
                    .HasConstraintName("tipoInmueblesolar_fk");
            });

            modelBuilder.Entity<SolarDireccion>(entity =>
            {
                entity.ToTable("solarDireccion");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.IdSolar).HasColumnName("idSolar");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SolarDireccion)
                    .HasForeignKey<SolarDireccion>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("solarDireccion_fk");
            });

            modelBuilder.Entity<SolarFoto>(entity =>
            {
                entity.ToTable("solarFoto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .IsUnicode(false);

                entity.Property(e => e.Solarid).HasColumnName("solarid");

                entity.HasOne(d => d.Solar)
                    .WithMany(p => p.SolarFoto)
                    .HasForeignKey(d => d.Solarid)
                    .HasConstraintName("solarFoto_fk");
            });

            modelBuilder.Entity<SolarPrecio>(entity =>
            {
                entity.ToTable("solarPrecio");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Monedaid).HasColumnName("monedaid");

                entity.Property(e => e.NotaPrecio)
                    .HasColumnName("notaPrecio")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SolarPrecio)
                    .HasForeignKey<SolarPrecio>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("solarPrecio_fk");

                entity.HasOne(d => d.Moneda)
                    .WithMany(p => p.SolarPrecio)
                    .HasForeignKey(d => d.Monedaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("solarPrecio_moneda_fk");
            });

            modelBuilder.Entity<TipoInmueble>(entity =>
            {
                entity.ToTable("tipoInmueble");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMoneda>(entity =>
            {
                entity.ToTable("tipoMoneda");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
