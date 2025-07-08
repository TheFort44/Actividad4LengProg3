using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Models;

public partial class Actividad4LengProg3Context : DbContext
{
    public Actividad4LengProg3Context()
    {
    }

    public Actividad4LengProg3Context(DbContextOptions<Actividad4LengProg3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacion> Calificacions { get; set; }

    public virtual DbSet<ListadoEstudiante> ListadoEstudiantes { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GBKGIUE\\SQLEXPRESS;Database=Actividad4LengProg3;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.HasKey(e => new { e.MatriculaEstudiante, e.CodigoMateria, e.Periodo }).HasName("PK__Califica__0124D2162AD6628F");

            entity.ToTable("Calificacion");

            entity.Property(e => e.MatriculaEstudiante)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodigoMateria)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Periodo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nota).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.CodigoMateriaNavigation).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.CodigoMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__Codig__4316F928");

            entity.HasOne(d => d.MatriculaEstudianteNavigation).WithMany(p => p.Calificacions)
                .HasPrincipalKey(p => p.Matricula)
                .HasForeignKey(d => d.MatriculaEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__Matri__4222D4EF");
        });

        modelBuilder.Entity<ListadoEstudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ListadoE__3214EC07124F549D");

            entity.HasIndex(e => e.Matricula, "UQ__ListadoE__0FB9FB4FD00E46D9").IsUnique();

            entity.Property(e => e.Carrera).HasMaxLength(100);
            entity.Property(e => e.CorreoInstitucional)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Matricula)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PorcentajeBeca).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TipoIngreso)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Turno)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Materia__06370DAD7FF9A994");

            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Carrera).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
