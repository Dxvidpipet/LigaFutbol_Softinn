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
    public class EditModelArbitro : PageModel
    {
        private readonly IRepositorioArbitro _repoArbitro;
        public Arbitro arbitro {get;set;}
        public EditModelArbitro (IRepositorioArbitro repoPaciente)
        {
            _repoArbitro = repoPaciente;
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
        public IActionResult OnPost(Arbitro arbitro)
        {
            _repoArbitro.UpdateArbitro(arbitro);
            return RedirectToPage("IndexArbitro");
        }
    }
}
