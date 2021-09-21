using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class Jugador
    {
        [Key]
        public int IdJugador { get; set; }
        public string NombreJugador { get; set; }
		public int NumeroJugador { get; set; }
		public string PosicionJugador { get; set; }
        public Equipo Equipo { set; get; }
    }
}