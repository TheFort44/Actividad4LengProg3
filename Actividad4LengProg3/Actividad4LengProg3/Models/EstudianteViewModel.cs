using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad4LengProg3.Models
{
    [Table("ListadoEstudiantes")]
    public class EstudianteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacío")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacío")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La matrícula debe tener entre 6 y 15 caracteres")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Seleccione una carrera")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "El correo institucional es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        [Display(Name = "Correo institucional")]
        public string CorreoInstitucional { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacío")]
        [Phone(ErrorMessage = "El número de teléfono no es válido")]
        [MinLength(10, ErrorMessage = "El número de teléfono debe tener al menos 10 dígitos")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Seleccione el género")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Seleccione el turno")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "Seleccione el tipo de ingreso")]
        [Display(Name = "Tipo de ingreso")]
        public string TipoIngreso { get; set; }

        [Display(Name = "¿Está becado?")]
        public bool Becado { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100")]
        [Display(Name = "Porcentaje de beca")]
        public decimal? PorcentajeBeca { get; set; }

        [NotMapped]
        [Display(Name = "Términos y condiciones")]
        public bool TerminosYCondiciones { get; set; }
    }
}