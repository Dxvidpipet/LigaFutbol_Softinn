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
    public class DetailsDirTecnicosModel : PageModel
    {
        private readonly IRepositorioDirTecnico _repoDirTecnico;
        public DirTecnico dirTecnico {get; set;}
        public DetailsDirTecnicosModel(IRepositorioDirTecnico repositorioDirTecnico)
        {
            _repoDirTecnico = repositorioDirTecnico;
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
    }
}
