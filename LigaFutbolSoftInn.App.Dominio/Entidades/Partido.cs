using System;
using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{
    public class Partido
    {
        [Key]
        public int IdPartido { get; set; }
        public DateTime FechaPartido { get; set; }
        public Equipo NombreEquipoLocal { get; set; }
		public Equipo NombreEquipoVisitante { get; set; }
		public int MarcadorLocal { get; set; }
		public int MarcadorVisitante { get; set; }
        public Estadio Estadio { set; get; }
		public Arbitro Arbitro { set; get; }
    }
}