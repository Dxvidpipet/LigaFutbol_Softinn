using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{
    public class Estadio
    {
        [Key]
        public int IdEstadio { get; set; }
         [Display(Name = "Nombre del estadio")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string NombreEstadio { get; set; }
         [Display(Name = "Dirección del estadio")]
        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string DireccionEstadio { get; set; }
        public Municipio Municipio { set; get; }
    }
}