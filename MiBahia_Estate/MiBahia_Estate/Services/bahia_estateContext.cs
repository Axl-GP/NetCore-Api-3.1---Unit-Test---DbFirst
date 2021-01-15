using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MiBahia_Estate
{
    public partial class bahia_estateContext : DbContext
    {
        public bahia_estateContext()
        {
        }

        public bahia_estateContext(DbContextOptions<bahia_estateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inmueble> Inmuebles { get; set; }
        public virtual DbSet<InmuebleDireccion> InmuebleDireccions { get; set; }
        public virtual DbSet<InmuebleFoto> InmuebleFotos { get; set; }
        public virtual DbSet<InmueblePrecio> InmueblePrecios { get; set; }
        public virtual DbSet<Propiedad> Propiedads { get; set; }
        public virtual DbSet<Solar> Solars { get; set; }
        public virtual DbSet<TipoInmueble> TipoInmuebles { get; set; }
        public virtual DbSet<TipoMonedum> TipoMoneda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-L2QEUDE\\SQLEXPRESS; database=bahia_estate;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Inmueble>(entity =>
            {
                entity.ToTable("Inmueble");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("area");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Destacado)
                    .HasColumnName("destacado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoInmuebleId).HasColumnName("tipoInmuebleID");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.TipoInmueble)
                    .WithMany(p => p.Inmuebles)
                    .HasForeignKey(d => d.TipoInmuebleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inmueble_TipoInmueble_fk");
            });

            modelBuilder.Entity<InmuebleDireccion>(entity =>
            {
                entity.ToTable("InmuebleDireccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Inmuebleid).HasColumnName("inmuebleid");

                entity.HasOne(d => d.Inmueble)
                    .WithMany(p => p.InmuebleDireccions)
                    .HasForeignKey(d => d.Inmuebleid)
                    .HasConstraintName("InmuebleDireccion_fk");
            });

            modelBuilder.Entity<InmuebleFoto>(entity =>
            {
                entity.ToTable("InmuebleFoto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Foto)
                    .IsUnicode(false)
                    .HasColumnName("foto");

                entity.Property(e => e.Inmuebleid).HasColumnName("inmuebleid");

                entity.HasOne(d => d.Inmueble)
                    .WithMany(p => p.InmuebleFotos)
                    .HasForeignKey(d => d.Inmuebleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InmuebleFoto_fk");
            });

            modelBuilder.Entity<InmueblePrecio>(entity =>
            {
                entity.ToTable("InmueblePrecio");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Monedaid).HasColumnName("monedaid");

                entity.Property(e => e.NotaPrecio)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("notaPrecio");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InmueblePrecio)
                    .HasForeignKey<InmueblePrecio>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InmueblePrecio_fk");
            });

            modelBuilder.Entity<Propiedad>(entity =>
            {
                entity.ToTable("propiedad");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

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

                entity.Property(e => e.Ducha).HasColumnName("ducha");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Propiedad)
                    .HasForeignKey<Propiedad>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inmueble_Propiedad_fk");
            });

            modelBuilder.Entity<Solar>(entity =>
            {
                entity.ToTable("solar");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("area");

                entity.Property(e => e.PrecioMetro)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("precioMetro");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Solar)
                    .HasForeignKey<Solar>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inmueble_Solar_fk");
            });

            modelBuilder.Entity<TipoInmueble>(entity =>
            {
                entity.ToTable("tipoInmueble");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<TipoMonedum>(entity =>
            {
                entity.ToTable("tipoMoneda");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
