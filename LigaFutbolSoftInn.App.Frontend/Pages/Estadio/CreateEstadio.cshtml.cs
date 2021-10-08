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
    public class CreateEstadioModel : PageModel
    {
         private readonly IRepositorioEstadio _repoEstadio;
        public Estadio estadio { get; set; }
        public CreateEstadioModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio = repoEstadio;
        }

        public void OnGet()
        {
            estadio = new Estadio();
        }

          public IActionResult OnPost(Estadio estadio)
        {
            if (ModelState.IsValid)
            {
                _repoEstadio.CreateEstadio(estadio);
                return RedirectToPage("IndexEstadio");
            }
            else
            {
                return Page();
            }
        }
    }
}
