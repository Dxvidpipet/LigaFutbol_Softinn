using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Pages
{
    public class CreateDirTecnicosModel : PageModel
    {
        private readonly IRepositorioDirTecnico _repoDirTecnico;
        public DirTecnico dirTecnico{get;set;}
        public CreateDirTecnicosModel(IRepositorioDirTecnico repoDirTecnico)
        {
            _repoDirTecnico = repoDirTecnico;
        }
        public void OnGet()
        {
            dirTecnico = new DirTecnico();
        }
        public IActionResult OnPost(DirTecnico dirTecnico)
        {
            if(ModelState.IsValid)
            {
                _repoDirTecnico.CreateDirTecnico(dirTecnico);
                return RedirectToPage("IndexDirTecnicos");
            }
            else
            {
                return Page();
            } 
        }
    }
}
