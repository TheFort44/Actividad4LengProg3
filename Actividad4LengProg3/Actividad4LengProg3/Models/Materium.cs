using System;
using System.Collections.Generic;

namespace Actividad4LengProg3.Models;

public partial class Materium
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int? Creditos { get; set; }

    public string Carrera { get; set; } = null!;

    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();
}
