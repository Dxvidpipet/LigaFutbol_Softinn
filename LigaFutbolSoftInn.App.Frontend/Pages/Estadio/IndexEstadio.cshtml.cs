using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LigaFutbolSoftInn.App.Persistencia;
using LigaFutbolSoftInn.App.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace LigaFutbolSoftInn.App.Frontend.Pages
{
    [Authorize]
    public class IndexEstadioModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        public IEnumerable<Estadio> estadios {get; set;}
        public IndexEstadioModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio= repoEstadio;
        }
        public void OnGet()
        {
            estadios = _repoEstadio.GetAllEstadios();
            
            //Console.WriteLine(estadios.First().Municipio.NombreMunicipio);
        }
        
        }
    }

