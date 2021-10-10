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
    public class CreateNovedadModel : PageModel
    {
        private readonly IRepositorioNovedad _repoNovedad;
        public Novedad novedad { get; set; }
        public CreateNovedadModel(IRepositorioNovedad repoNovedad)
        {
            _repoNovedad = repoNovedad;
        }

        public void OnGet()
        {
            novedad = new Novedad();
        }

        public IActionResult OnPost(Novedad novedad)
        {
            if (ModelState.IsValid)
            {
                _repoNovedad.CreateNovedad(novedad);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
