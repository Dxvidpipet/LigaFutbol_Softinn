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
    public class IndexNovedadModel : PageModel
    {
     private readonly IRepositorioNovedad _repoNovedad;
        public IEnumerable<Novedad> novedades {get; set;}
        public string bActual {get; set;}
        public IndexNovedadModel(IRepositorioNovedad repoNovedad)
        {
            _repoNovedad= repoNovedad;
        }
        public void OnGet(string b)
        {
            if(String.IsNullOrEmpty(b))
            {
                bActual = "";
                novedades = _repoNovedad.GetAllNovedades();
            }
            else
            {
                bActual = b;
                novedades = _repoNovedad.SearchNovedades(b);
            }
        }
        
    }
}
