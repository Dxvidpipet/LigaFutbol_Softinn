using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class Municipio
    {
        [Key]
        public int IdMunicipio { get; set; }
        public string NombreMunicipio { get; set; }
        

    }
}