using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class Equipo
    {
        [Key]
        public int IdEquipo { get; set; }
        public string NombreEquipo { get; set; }
        public Municipio Municipio { set; get; }
    }
}