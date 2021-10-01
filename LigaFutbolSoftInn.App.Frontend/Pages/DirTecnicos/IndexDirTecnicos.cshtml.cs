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
    public class IndexDirTecnicosModel : PageModel
    {
        private readonly IRepositorioDirTecnico _repoDirTecnico;
        public IEnumerable<DirTecnico> dirTecnico {get; set;}
        public IndexDirTecnicosModel(IRepositorioDirTecnico repoDirTecnico)
        {
            _repoDirTecnico = repoDirTecnico;
        }
        public void OnGet()
        {
            dirTecnico = _repoDirTecnico.GetAllDirTecnicos();
        }
    }
}
