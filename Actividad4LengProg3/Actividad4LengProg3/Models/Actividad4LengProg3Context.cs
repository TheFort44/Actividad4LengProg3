using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Models
{
    public class Actividad4LengProg3Context : DbContext
    {
        public Actividad4LengProg3Context(DbContextOptions options) : base(options)
        {
        }


        public DbSet<EstudianteViewModel> Estudiante { get; set; }
        //public DbSet<Materium> materia { get; set; }

    }
    }
