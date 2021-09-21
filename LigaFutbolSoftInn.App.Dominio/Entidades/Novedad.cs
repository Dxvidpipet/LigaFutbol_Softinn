using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class Novedad
    {
        [Key]
        public int IdNovedad { get; set; }
        public TipoNovedad TipoNovedad { get; set; }
        public int MinutoPartidoNovedad { get; set; }
		public Jugador Jugador { get; set; }
        public Partido Partido { set; get; }
    }
}