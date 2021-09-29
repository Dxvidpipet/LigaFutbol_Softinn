using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LigaFutbolSoftInn.App.Persistencia;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Frontend.Pages.Partido
{
    public class IndexPartidoModel : PageModel
    {
         private readonly IRepositorioPartido _repoPartido;
         //public IEnumerable<Partido> Partidos {get; set;}
         public IndexPartidoModel(IRepositorioPartido repoPartido)
        {
            _repoPartido = repoPartido;
        }
        public void OnGet()
        {
             partidos = _repoPartido.GetAllPartidos();
        }
    }
}
