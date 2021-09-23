using System.ComponentModel.DataAnnotations;
namespace LigaFutbolSoftInn.App.Dominio
{
    public class Arbitro
    {
        [Key]
        public int IdArbitro { get; set; }
		public string NombreArbitro { get; set; }
        public string DocumentoArbitro { get; set; }
		public string TelefonoArbitro { get; set; }
		public string ColegioArbitro { get; set; }
    }
}