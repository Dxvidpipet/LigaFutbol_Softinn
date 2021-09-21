using System.ComponentModel.DataAnnotations;

namespace LigaFutbolSoftInn.App.Dominio
{ 
    public class DirTecnico
    {
        [Key]
        public int IdDirTecnico { get; set; }
        public string NombreDirTecnico { get; set; }
		public string DocumentoDirTecnico { get; set; }
		public string TelefonoDirTecnico { get; set; }
        public Equipo Equipo { set; get; }
    }
}