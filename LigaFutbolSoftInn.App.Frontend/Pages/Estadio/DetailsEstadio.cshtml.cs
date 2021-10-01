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
    public class DetailsEstadioModel : PageModel
    {
   private readonly IRepositorioEstadio _repoEstadio;
        public Estadio estadio {get; set;}
        public DetailsEstadioModel(IRepositorioEstadio repositorioEstadio)
        {
            _repoEstadio = repositorioEstadio;
        }
        public IActionResult OnGet(int id)
        {
            estadio = _repoEstadio.ReadEstadio(id);
            if (estadio == null)
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
