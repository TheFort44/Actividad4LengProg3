using System;
using System.Collections.Generic;

namespace Actividad4LengProg3.Models;

public partial class ListadoEstudiante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Matricula { get; set; } = null!;

    public string Carrera { get; set; } = null!;

    public string CorreoInstitucional { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Turno { get; set; }

    public string? TipoIngreso { get; set; }

    public bool Becado { get; set; }

    public decimal? PorcentajeBeca { get; set; }

    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();
}
