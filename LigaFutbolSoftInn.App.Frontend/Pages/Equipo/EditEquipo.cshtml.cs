using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Frontend.Pages
{
    public class EditEquipoModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioMunicipio _repoMunicipio;
        public Equipo equipo { get; set; }
        public IEnumerable<Municipio> municipios { get; set; }
        public EditEquipoModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio repoMunicipio)
        {
            _repoEquipo = repoEquipo;
             _repoMunicipio = repoMunicipio;
        }

        public IActionResult OnGet(int id)
        {
            equipo = _repoEquipo.ReadEquipo(id);
            municipios = _repoMunicipio.GetAllMunicipios();
            if (equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Equipo equipo,int idEquipo, int idMunicipio)
        {
            
            _repoEquipo.UpdateEquipo(equipo,idEquipo, idMunicipio);
            return RedirectToPage("IndexEquipo");
        }
    }
}
