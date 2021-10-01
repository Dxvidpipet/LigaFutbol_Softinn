using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class Equipo
    {
        [Key]
        public int IdEquipo { get; set; }
        public string NombreEquipo { get; set; }
        //[ForeignKey("Municipio")]
        //public int MunicipioId { get; set; }
        public Municipio Municipio { set; get; }
    }
}