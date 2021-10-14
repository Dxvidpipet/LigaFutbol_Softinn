using System.Collections;
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
    public class IndexEstadisticasModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioPartido _repoPartido;
        public IEnumerable<Equipo> equipos {get; set;}
        public IEnumerable<Partido> partidos {get; set;}
        
        public IndexEstadisticasModel(IRepositorioEquipo repoEquipo, IRepositorioPartido repoPartido)
        {
            _repoEquipo = repoEquipo;
            _repoPartido = repoPartido; 
        }
        
        public void OnGet()
        {
            equipos = _repoEquipo.GetAllEquipos();
            partidos = _repoPartido.GetAllPartidos();
        }
    }
}
