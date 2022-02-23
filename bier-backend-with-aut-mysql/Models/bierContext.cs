using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bier_backend_with_aut_mysql.Models
{
    public partial class bierContext : IdentityDbContext<IdentityUser>
    {
        public bierContext()
        {
        }

        public bierContext(DbContextOptions<bierContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bier> Biers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=ConnectionStrings:MysqlDb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Bier>(entity =>
            {
                entity.ToTable("bier");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Brouwer)
                    .HasMaxLength(40)
                    .HasColumnName("brouwer");

                entity.Property(e => e.Gisting)
                    .HasMaxLength(40)
                    .HasColumnName("gisting");

                entity.Property(e => e.InkoopPrijs)
                    .HasPrecision(5, 2)
                    .HasColumnName("inkoop_prijs");

                entity.Property(e => e.Naam)
                    .HasMaxLength(40)
                    .HasColumnName("naam");

                entity.Property(e => e.Perc).HasColumnName("perc");

                entity.Property(e => e.Type)
                    .HasMaxLength(40)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
