using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LigaFutbolSoftInn.App.Persistencia;
using LigaFutbolSoftInn.App.Dominio;
namespace LigaFutbolSoftInn.App.Frontend.Pages
{
    public class IndexEquipoModel : PageModel
    {
     private readonly IRepositorioEquipo _repoEquipo;
        public IEnumerable<Equipo> equipos {get; set;}
        public IndexEquipoModel(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo= repoEquipo;
        }
        public void OnGet()
        {
            equipos = _repoEquipo.GetAllEquipos();
        }
    }
}
