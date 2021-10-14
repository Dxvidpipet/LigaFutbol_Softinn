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
        public Equipo NombreEquipoLocal { get; set; }
		public Equipo NombreEquipoVisitante { get; set; }
        [Display(Name = "Marcador Equipo Local")]
		public int MarcadorLocal { get; set; }
        [Display(Name = "Marcador Equipo Visitante")]
		public int MarcadorVisitante { get; set; }
        public Estadio Estadio { set; get; }
		public Arbitro Arbitro { set; get; }
    }
}