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
    public class IndexPartidoModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioArbitro _repoArbitro;
        private readonly IRepositorioEstadio _repoEstadio;
        public IEnumerable<Partido> partidos { get; set; }
        public string bActual { get; set; }
        public int gActual { get; set; }
       
        public string NombreFiltro { get; set; }
        public IEnumerable<Equipo> equiposLocal { get; set; }
        public IEnumerable<Equipo> equiposVisitante { get; set; }
        public IEnumerable<Arbitro> arbitros { get; set; }
        public IEnumerable<Estadio> estadios { get; set; }
        public IndexPartidoModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo, IRepositorioArbitro repoArbitro, IRepositorioEstadio repoEstadio)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
            _repoArbitro = repoArbitro;
            _repoEstadio = repoEstadio;
        }
        public void OnGet(string b, int g)

        {

            
            partidos = _repoPartido.GetAllPartidos();

          
            switch (g)
            {
                case 0:
                    gActual = g;
                    break;
                case 1:
                    gActual = g;
                    NombreFiltro="Nombre Equipo local";
                    equiposLocal = _repoEquipo.GetAllEquipos();
                    break;
                case 2:
                    gActual = g;
                    NombreFiltro="Nombre Equipo Visitante";
                    equiposVisitante = _repoEquipo.GetAllEquipos();
                    break;
                case 3:
                    gActual = g;
                    NombreFiltro="Nombre Estadio";
                    estadios = _repoEstadio.GetAllEstadios();
                    break;
                case 4:
                    gActual = g;
                    NombreFiltro="Nombre Arbitro";
                    arbitros = _repoArbitro.GetAllArbitros();
                    break;

            }

            if(g == 0)
                     {
                        
                        gActual=0;
                        partidos = _repoPartido.GetAllPartidos();
                        //equipos = _repoEquipo.GetAllEquipos();
                        //
                        //equipos=_repoEquipo.SearchEquipo(b);
                         //equipos = _repoEquipo.ReadEquipo(id);
                     }
                 else
                    {

                        
                        gActual=g;
                        bActual="";

                        if(String.IsNullOrEmpty(b))
                     {
                        bActual="";
                        partidos = _repoPartido.GetAllPartidos();

                     }
                     else  
                     { 
                        partidos=_repoPartido.SearchPartidoAll(b,g);
                        
                     }
                    }

            //equiposLocal =  _repoEquipo.GetAllEquipos();
            //equiposVisitante =  _repoEquipo.GetAllEquipos();
            //arbitros = _repoArbitro.GetAllArbitros();


        }
    }
}
