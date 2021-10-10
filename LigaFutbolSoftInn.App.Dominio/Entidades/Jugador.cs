using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class Jugador
    {
        [Key]
        public int IdJugador { get; set; }
        [Display(Name = "Nombre del Jugador")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string NombreJugador { get; set; }
        [Display(Name = "Numero del Jugador")]
        [Required(ErrorMessage = "El numero es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
		public int NumeroJugador { get; set; }
        [Display(Name = "Posicion del Jugador")]
        [Required(ErrorMessage = "El numero es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 99 caracteres")]
		public string PosicionJugador { get; set; }
        [Display(Name = "Equipo")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public Equipo Equipo { set; get; }
    }
}