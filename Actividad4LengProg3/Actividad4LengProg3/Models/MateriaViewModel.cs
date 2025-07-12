using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Actividad4LengProg3.Models
{
    public class MateriaViewModel
    {
        [Key]
        [Required(ErrorMessage = "Digite el codigo de la materia")]
        [StringLength(30)]
        [Column("Codigo")]
        [Display(Name = "Código de la materia")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre de la materia es obligatorio")]
        [StringLength(100)]
        [Column("Nombre")]
        [Display(Name = "Nombre de la materia")]
        public string Nombre { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "La cantidad de creditos es de 1 a 4")]
        [Column("Creditos")]
        [Display(Name = "Créditos")]
        public int? Creditos { get; set; }

        [Required(ErrorMessage = "Seleccione una carrera")]
        [StringLength(80)]
        [Column("Carrera")]
        [Display(Name = "Carrera")]
        public string Carrera { get; set; }
    }
}
