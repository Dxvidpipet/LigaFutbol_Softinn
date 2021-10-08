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
    public class EditEstadioModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        public Estadio estadio { get; set; }
        public EditEstadioModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio = repoEstadio;
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

        public IActionResult OnPost(Estadio estadio)
        {
            _repoEstadio.UpdateEstadio(estadio);
            return RedirectToPage("IndexEstadio");
        }
    }
}
