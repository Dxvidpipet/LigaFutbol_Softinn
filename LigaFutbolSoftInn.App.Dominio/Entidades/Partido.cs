using System;
using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{
    public class Partido
    {
        [Key]
        public int IdPartido { get; set; }
        [Display(Name = "Fecha del partido")]
        [Required(ErrorMessage = "La Fecha es Obligatoria")]
        public DateTime FechaPartido { get; set; }
        [Display(Name = "Equipo Local")]
        [Required(ErrorMessage = "Ingrese Equipo")]
        public Equipo NombreEquipoLocal { get; set; }
        [Display(Name = "Equipo Visitante")]
        [Required(ErrorMessage = "Ingrese Equipo")]
		public Equipo NombreEquipoVisitante { get; set; }
        [Display(Name = "Marcador Equipo Local")]
		public int MarcadorLocal { get; set; }
        [Display(Name = "Marcador Equipo Visitante")]
		public int MarcadorVisitante { get; set; }
        [Display(Name = "Estadio")]
        [Required(ErrorMessage = "Ingrese Estadio")]
        public Estadio Estadio { set; get; }
        [Display(Name = "Arbitro")]
        [Required(ErrorMessage = "Ingrese Arbitro")]
		public Arbitro Arbitro { set; get; }
    }
}