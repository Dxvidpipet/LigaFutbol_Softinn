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
    public class DetailsPartidoModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        public Partido partido {get; set;}
        public DetailsPartidoModel(IRepositorioPartido repositorioPartido)
        {
            _repoPartido= repositorioPartido;
        }
        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.ReadPartido(id);
            if (partido == null)
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
