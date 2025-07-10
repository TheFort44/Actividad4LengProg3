using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Models
{
    public class Actividad4LengProg3Context : DbContext
    {
        public DbSet<EstudianteViewModel> Estudiante { get; set; }
        public DbSet<MateriaViewModel> Materia { get; set; }
        public DbSet<CalificacionViewModel> Calificacion { get; set; }

        public Actividad4LengProg3Context(DbContextOptions<Actividad4LengProg3Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales si son necesarias
        }
    }
}
