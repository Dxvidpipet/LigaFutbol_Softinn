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
    public class DetailsNovedadModel : PageModel
    {
        private readonly IRepositorioNovedad _repoNovedad;
        public Novedad novedad {get; set;}
        public DetailsNovedadModel(IRepositorioNovedad repositorioNovedad)
        {
            _repoNovedad = repositorioNovedad;
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
    }
}    