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
    public class DetailsArbitrosModel : PageModel
    {
        private readonly IRepositorioArbitro _repoArbitro;
        public Arbitro arbitro {get; set;}
        public DetailsArbitrosModel(IRepositorioArbitro repositorioArbitro)
        {
            _repoArbitro = repositorioArbitro;
        }
        public IActionResult OnGet(int id)
        {
            arbitro = _repoArbitro.ReadArbitro(id);
            if (arbitro == null)
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
