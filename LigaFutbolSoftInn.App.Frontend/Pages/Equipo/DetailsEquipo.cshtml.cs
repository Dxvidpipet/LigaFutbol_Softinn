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
    public class DetailsEquipoModel : PageModel
    {
       private readonly IRepositorioEquipo _repoEquipo;
        public Equipo equipo {get; set;}
        public DetailsEquipoModel(IRepositorioEquipo repositorioEquipo)
        {
            _repoEquipo = repositorioEquipo;
        }
        public IActionResult OnGet(int id)
        {
            equipo = _repoEquipo.ReadEquipo(id);
            if (equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
