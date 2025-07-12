using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad4LengProg3.Models
{
    [Table("Calificacion")]
    public class CalificacionViewModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La matrícula del estudiante es obligatoria.")]
        [Column ("MatriculaEstudiante")]
        [Display(Name = "Seleccione la matricula del estudiante")]
        public string MatriculaEstudiante { get; set; } = null!;

        [Required(ErrorMessage = "El código de la materia es obligatorio.")]
        [Column("CodigoMateria")]
        [Display(Name = "Seleccione la asignatura")]
        public string CodigoMateria { get; set; } = null!;

        [Required(ErrorMessage = "La nota es obligatoria.")]
        [Range(0, 100, ErrorMessage = "La nota debe estar entre 0 y 100.")]
        [Column("Nota")]
        [Display(Name = "Nota del estudiante")]
        public decimal? Nota { get; set; }

        [Required(ErrorMessage = "El periodo es obligatorio.")]
        [Column("Periodo")]
        [Display(Name = "Periodo académico")]
        public string? Periodo { get; set; }

    }
}