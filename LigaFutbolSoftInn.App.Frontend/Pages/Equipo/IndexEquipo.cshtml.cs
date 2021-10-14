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
    public class IndexEquipoModel : PageModel
    {
     private readonly IRepositorioEquipo _repoEquipo;
     private readonly IRepositorioMunicipio _repoMunicipio;
        public IEnumerable<Equipo> equipos {get; set;}
       //public Equipo equipo {get; set;}
        public string bActual {get; set;}
        public string gActual  {get; set;}

        public IEnumerable<Municipio> municipios { get; set; }

        public IndexEquipoModel(IRepositorioEquipo repoEquipo,IRepositorioMunicipio repoMunicipio)
        {
            _repoEquipo= repoEquipo;
            _repoMunicipio= repoMunicipio;
        }
        public void OnGet(string b, string g)
        {
            string busqueda;
            municipios = _repoMunicipio.GetAllMunicipios();
            equipos = _repoEquipo.GetAllEquipos();
                 if(String.IsNullOrEmpty(g))
                     {
                        gActual="";
                        //equipos = _repoEquipo.GetAllEquipos();
                        //
                        if(String.IsNullOrEmpty(b))
                         {
                           bActual="";  
                           gActual=""; 
                         }
                         else   
                         {
                        bActual=b;
                        busqueda="";
                        equipos=_repoEquipo.SearchEquipoMuni(b,g,busqueda);

                         }
                        //equipos=_repoEquipo.SearchEquipo(b);
                         //equipos = _repoEquipo.ReadEquipo(id);
                     }
                 else
                    {
                        gActual=g;
                        bActual=b;
                        busqueda="Equipo";
                        if(String.IsNullOrEmpty(b))
                         {
                        b="";
                         }
                        equipos=_repoEquipo.SearchEquipoMuni(b,g,busqueda);
                    }

            }

            

           
            
            //Console.WriteLine(equipos.First().Municipio.NombreMunicipio);
        
    }
}
