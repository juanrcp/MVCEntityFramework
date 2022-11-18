using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCEntityFrameworkDAL.Modelo;

public partial class DeveloferContext : DbContext
{
    public DeveloferContext()
    {
    }

    public DeveloferContext(DbContextOptions<DeveloferContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Develofer;User Id=postgres;Password=fp13DAW");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("areas_pkey");

            entity.ToTable("areas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area1)
                .HasMaxLength(100)
                .HasColumnName("area");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("empleados_pkey");

            entity.ToTable("empleados");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdArea)
                .HasConstraintName("empleados_areas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
