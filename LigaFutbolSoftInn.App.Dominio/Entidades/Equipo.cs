using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class Equipo
    {
        [Key]
        public int IdEquipo { get; set; }

        [Display(Name = "Nombre del Equipo")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string NombreEquipo { get; set; }
        public Municipio Municipio { set; get; }
    }
}