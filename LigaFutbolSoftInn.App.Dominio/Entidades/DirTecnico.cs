using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class DirTecnico
    {
        [Key]
        public int IdDirTecnico { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [Display(Name ="Nombre Director Técnico")]
        public string NombreDirTecnico { get; set; }
        [Required(ErrorMessage ="El documento es obligatorio")]
        [Display(Name ="Documento Director Técnico")]
		public string DocumentoDirTecnico { get; set; }
        [Display(Name ="Teléfono Director Técnico")]
		public string TelefonoDirTecnico { get; set; }
        [Display(Name ="Equipo Director Técnico")]
        public Equipo Equipo { set; get; }
    }
}