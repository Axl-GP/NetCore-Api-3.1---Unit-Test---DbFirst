using System;
using MiBahia_Estate.Solares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

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

        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyAddresses> PropertiesAddresses { get; set; }
        public virtual DbSet<PropertyPhotos> PropertiesPhotos { get; set; }
        public virtual DbSet<PropertyPrice> PropertyPrices { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<BuildingSite> BuildingSites { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<CoinType> CoinTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("area");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Outstanding)
                    .HasColumnName("outstanding")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PropertyTypeId).HasColumnName("PropertyTypeID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inmueble_TipoInmueble_fk");
            });

            modelBuilder.Entity<PropertyAddresses>(entity =>
            {
                entity.ToTable("PropertyAddress");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("Address");

                entity.Property(e => e.PropertyId).HasColumnName("propertyid");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.PropertyAddresses)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("PropertyAddress_fk");
            });

            modelBuilder.Entity<PropertyPhotos>(entity =>
            {
                entity.ToTable("PropertyPhotos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PhotoPath)
                    .IsUnicode(false)
                    .HasColumnName("photopath");

                entity.Property(e => e.PropertyId).HasColumnName("propertyid");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.PropertyPhotos)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PropertyPhotos_fk");
            });

            modelBuilder.Entity<PropertyPrice>(entity =>
            {
                entity.ToTable("PropertyPrice");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .UseIdentityColumn();

                entity.Property(e => e.CoinId)
                      .HasColumnName("CoinId")
                      .IsRequired();

                entity.Property(e => e.PriceNotes)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("priceNotes");

                entity.Property(e => e.Price)
                      .HasColumnName("price")
                      .IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PropertyPrice)
                    .HasForeignKey<PropertyPrice>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PropertyPrice_fk");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.ToTable("House");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Gym)
                    .HasColumnName("Gym")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WashingArea)
                    .HasColumnName("washingArea")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ServiceRoom)
                    .HasColumnName("serviceRoom")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Rooms)
                      .HasColumnName("rooms")
                      .IsRequired();

                entity.Property(e => e.Bathrooms)
                      .HasColumnName("bathrooms")
                      .IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.House)
                    .HasForeignKey<House>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Property_House_fk");
            });

            modelBuilder.Entity<BuildingSite>(entity =>
            {
                entity.ToTable("BuildingSite");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("area");

                entity.Property(e => e.PricePerMeter)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("pricePerMeter");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.BuildingSite)
                    .HasForeignKey<BuildingSite>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Property_BuildingSite_fk");
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.ToTable("PropertyType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<CoinType>(entity =>
            {
                entity.ToTable("CoinType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
