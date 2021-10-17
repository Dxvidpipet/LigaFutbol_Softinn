using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Pages
{
    public class AddEquipoModel : PageModel
    {
        private readonly IRepositorioDirTecnico _repoDirTecnico;
        private readonly IRepositorioEquipo _repoEquipo;
        public DirTecnico dirTecnico{get;set;}
        public IEnumerable<Equipo> equipos {get;set;}
        public AddEquipoModel(IRepositorioDirTecnico repoDirTecnico, IRepositorioEquipo repoEquipo)
        {
            _repoDirTecnico = repoDirTecnico;
            _repoEquipo = repoEquipo; 
        }
        public void OnGet(int id)
        {
            dirTecnico = _repoDirTecnico.ReadDirTecnico(id);
            equipos = _repoEquipo.GetAllEquipos();
        }
        public IActionResult OnPost(int idDirTecnico, int idEquipo)
        {
            _repoDirTecnico.AsignarDirTecnicoEquipo(idDirTecnico, idEquipo);
            return RedirectToPage("DetailsDirTecnicos", new {id = idDirTecnico});
        }
    }
}
