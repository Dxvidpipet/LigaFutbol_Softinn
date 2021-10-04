using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class Municipio
    {
        [Key]
        public int IdMunicipio { get; set; }
        [Display(Name = "Nombre del municipio")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string NombreMunicipio { get; set; }
    }
}