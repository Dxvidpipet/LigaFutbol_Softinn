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
    public class CreateModelArbitro : PageModel
    {
        private readonly IRepositorioArbitro _repoArbitro;
        public Arbitro arbitro{get;set;}
        public CreateModelArbitro(IRepositorioArbitro repoArbitro)
        {
            _repoArbitro=repoArbitro;
        }
        public void OnGet()
        {
            arbitro = new Arbitro();
        }
        public IActionResult OnPost(Arbitro arbitro)
        {
            if(ModelState.IsValid)
            {
                _repoArbitro.CreateArbitro(arbitro);
                return RedirectToPage("IndexArbitro");
            }
            else
            {
                return Page();
            } 
        }
    }
}
