using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{
    public class Estadio
    {
        [Key]
        public int IdEstadio { get; set; }
        public string NombreEstadio { get; set; }
        public string DireccionEstadio { get; set; }
        public Municipio Municipio { set; get; }
    }
}