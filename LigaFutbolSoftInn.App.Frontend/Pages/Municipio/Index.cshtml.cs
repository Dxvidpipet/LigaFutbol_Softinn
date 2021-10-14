using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LigaFutbolSoftInn.App.Persistencia;
using LigaFutbolSoftInn.App.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace LigaFutbolSoftInn.App.Frontend.Pages
{
    [Authorize]
    public class IndexMunicipioModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        public IEnumerable<Municipio> municipios {get; set;}
        public string bActual {get; set;}
        public IndexMunicipioModel(IRepositorioMunicipio repoMunicipio)
        {
            _repoMunicipio = repoMunicipio;
        }
        public void OnGet(string b)
        {
            if (String.IsNullOrEmpty(b))
            {
                bActual = "";
                municipios = _repoMunicipio.GetAllMunicipios();
            }
            else
            {
                bActual = b;
                municipios = _repoMunicipio.SearchMunicipios(b);
            }
        }
    }
}
