using System;
using System.Collections.Generic;

namespace Actividad4LengProg3.Models;

public partial class Calificacion
{
    public string MatriculaEstudiante { get; set; } = null!;

    public string CodigoMateria { get; set; } = null!;

    public decimal? Nota { get; set; }

    public string Periodo { get; set; } = null!;

    public virtual Materium CodigoMateriaNavigation { get; set; } = null!;

  //public virtual ListadoEstudiante MatriculaEstudianteNavigation { get; set; } = null!;
}
