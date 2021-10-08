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
    public class EditDirTecnicosModel : PageModel
    {
        private readonly IRepositorioDirTecnico _repoDirTecnico;
        public DirTecnico dirTecnico {get;set;}
        public EditDirTecnicosModel (IRepositorioDirTecnico repoDirTecnico)
        {
            _repoDirTecnico = repoDirTecnico;
        }
        public IActionResult OnGet(int id)
        {
            dirTecnico = _repoDirTecnico.ReadDirTecnico(id);
            if (dirTecnico == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(DirTecnico dirTecnico)
        {
            _repoDirTecnico.UpdateDirTecnico(dirTecnico);
            return RedirectToPage("IndexDirTecnicos");
        }
    }
}
