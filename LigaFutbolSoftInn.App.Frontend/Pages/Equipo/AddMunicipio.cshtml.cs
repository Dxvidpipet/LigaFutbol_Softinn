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
    public class AddMunicipioModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioMunicipio _repoMunicipio;
        public Equipo equipo { get; set; }
        public IEnumerable<Municipio> municipios { get; set; }
        public AddMunicipioModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio repoMunicipio)
        {
            _repoEquipo = repoEquipo;
            _repoMunicipio = repoMunicipio;
        }

        public void OnGet(int id)
        {
            equipo = _repoEquipo.ReadEquipo(id);
            municipios = _repoMunicipio.GetAllMunicipios();
        }

        public IActionResult OnPost(int idEquipo, int idMunicipio)
        {
            _repoEquipo.AsignarMunicipio(idEquipo, idMunicipio);
            return RedirectToPage("DetailsEquipo", new{id = idEquipo});
        }
    }
}
