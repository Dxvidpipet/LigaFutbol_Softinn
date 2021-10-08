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
    public class CreateEquipoModel : PageModel
    {
       private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioMunicipio _repoMunicipio;
        public Equipo equipo { get; set; }
        public IEnumerable<Municipio> municipios { get; set; }
        public CreateEquipoModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio repoMunicipio)
        {
            _repoEquipo = repoEquipo;
            _repoMunicipio = repoMunicipio;
        }

        public void OnGet()
        {
            equipo = new Equipo();
            municipios = _repoMunicipio.GetAllMunicipios();
        }

        public IActionResult OnPost(Equipo equipo, int idMunicipio)
        {

            if (ModelState.IsValid)
            {

              
             _repoEquipo.CreateEquipo(equipo);
              
             _repoEquipo.AsignarMunicipios(equipo, idMunicipio);
                return RedirectToPage("IndexEquipo");
            }
            else
            {
                
            if (equipo.NombreEquipo!= null)
            {
                _repoEquipo.CreateEquipo(equipo);
                return RedirectToPage("IndexEquipo");
               
            }else{
                 municipios = _repoMunicipio.GetAllMunicipios();
                 return Page();
                }

               
            }
        }
    }
}
