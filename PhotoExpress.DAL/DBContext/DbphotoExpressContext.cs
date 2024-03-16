using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PhotoExpress.Model;

namespace PhotoExpress.DAL.DBContext;

public partial class DbphotoExpressContext : DbContext
{
    public DbphotoExpressContext()
    {
    }

    public DbphotoExpressContext(DbContextOptions<DbphotoExpressContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<ModificacionEvento> ModificacionEventos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.ToTable("Evento");

            entity.Property(e => e.EventoId).ValueGeneratedNever();
            entity.Property(e => e.DireccionInstitucion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.NombreInstitucion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroReferencia)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ModificacionEvento>(entity =>
        {
            entity.HasKey(e => e.ModificacionId);

            entity.ToTable("ModificacionEvento");

            entity.Property(e => e.ModificacionId).ValueGeneratedNever();
            entity.Property(e => e.DetalleActual)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DetalleAnterior)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Evento).WithMany(p => p.ModificacionEventos)
                .HasForeignKey(d => d.EventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ModificacionEvento_Evento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
