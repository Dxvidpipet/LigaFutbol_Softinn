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
    public class EditNovedadModel : PageModel
    {
        private readonly IRepositorioNovedad _repoNovedad;
        public Novedad novedad {get;set;}
        public EditNovedadModel (IRepositorioNovedad repoNovedad)
        {
            _repoNovedad = repoNovedad;
        }
        public IActionResult OnGet(int id)
        {
            novedad = _repoNovedad.ReadNovedad(id);
            if (novedad == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Novedad novedad)
        {
            _repoNovedad.UpdateNovedad(novedad);
            return RedirectToPage("Index");
        }
    }
}
