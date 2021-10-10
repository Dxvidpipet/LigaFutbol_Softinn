using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class Novedad
    {
        [Key]
        public int IdNovedad { get; set; }
        [Display(Name = "Tipo de Novedad")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public TipoNovedad TipoNovedad { get; set; }
        [Display(Name = "Novedad Partido")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public int MinutoPartidoNovedad { get; set; }
        [Display(Name = "Novedad del Jugador")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
		public Jugador Jugador { get; set; }
        public Partido Partido { set; get; }
    }
}