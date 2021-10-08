using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{
    public class Arbitro
    {
        [Key]
        public int IdArbitro { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [Display(Name ="Nombre Árbitro")]
		public string NombreArbitro { get; set; }
        [Required(ErrorMessage ="El documento es obligatorio")]
        [Display(Name ="Documento Árbitro")]
        public string DocumentoArbitro { get; set; }
        [Required(ErrorMessage ="El telefono es obligatorio")]
        [Display(Name ="Teléfono Árbitro")]
		public string TelefonoArbitro { get; set; }
        [Display(Name ="Colegio del Árbitro")]
		public string ColegioArbitro { get; set; }
    }
}