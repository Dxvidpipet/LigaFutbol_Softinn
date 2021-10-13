using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioEquipo: IRepositorioEquipo
    {
        /*
        private readonly AppContext _appContext;

        public RepositorioEquipo(AppContext appContext)
        {
            _appContext = appContext;
        }
        */
        private readonly AppContext _appContext = new AppContext();
        IEnumerable<Equipo> IRepositorioEquipo.GetAllEquipos()
        {
            return _appContext.Equipos
            .Include(p => p.Municipio);
        }

       
         IEnumerable<Equipo> IRepositorioEquipo.SearchEquipoMuni(string nombreequipo,string nombremuni,string busqueda)
        {
           if(String.IsNullOrEmpty(busqueda))
            {
                return _appContext.Equipos.Where(e =>e.NombreEquipo.Contains(nombreequipo));  
            }
            else
            {
                return _appContext.Equipos.Where(e => e.Municipio.NombreMunicipio == nombremuni && e.NombreEquipo.Contains(nombreequipo));
                     
            }
            // .Where(e => e.Equipo == (Equipo)nombre);
             //.Include(p => p.Municipio.Contains(nombre));
        }



        Equipo IRepositorioEquipo.CreateEquipo(Equipo equipo)
        {
            var equipoAdicionado = _appContext.Equipos.Add(equipo);
            _appContext.SaveChanges();
            return equipoAdicionado.Entity;
        }

        Equipo IRepositorioEquipo.ReadEquipo(int idEquipo)
        {
            var equipo = _appContext.Equipos
                        .Where(e => e.IdEquipo == idEquipo)
                        .Include(p => p.Municipio)
                        .FirstOrDefault();
            return equipo;

        }

        

        string IRepositorioEquipo.DeleteEquipo(int idEquipo)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(m => m.IdEquipo == idEquipo);
            if (equipoEncontrado == null)
                return "Equipo no encontrado!";
            _appContext.Equipos.Remove(equipoEncontrado);
            _appContext.SaveChanges();
            return "Equipo eliminado!";
        }


        Municipio IRepositorioEquipo.UpdateEquipo(Equipo equipo,int idEquipo, int idMunicipio)
        {

            var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
            
            if (equipoEncontrado != null)
            { 
                var municipioEncontrado = _appContext.Municipios.Find(idMunicipio);
                if (municipioEncontrado != null)
                { 
                    
                    equipoEncontrado.NombreEquipo =equipo.NombreEquipo;
                  
                    equipoEncontrado.Municipio = municipioEncontrado;
                  
                    _appContext.SaveChanges();
                }
                return municipioEncontrado;
            }
            return null;

        }




       /*Equipo IRepositorioEquipo.UpdateEquipo(Equipo equipo)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(m => m.IdEquipo == equipo.IdEquipo);
            if (equipoEncontrado != null)
            {
                equipoEncontrado.NombreEquipo = equipo.NombreEquipo;
                equipoEncontrado.Municipio = equipo.Municipio;
                _appContext.SaveChanges();
            }
            
            return equipoEncontrado;
        }*/

        Municipio IRepositorioEquipo.AsignarMunicipios(Equipo equipo, int idMunicipio)
        {
            
             var equipoEncontrado = _appContext.Equipos.FirstOrDefault(m => m.NombreEquipo == equipo.NombreEquipo);
            
          
            if (equipoEncontrado != null)
            { 
                var municipioEncontrado = _appContext.Municipios.Find(idMunicipio);
                if (municipioEncontrado != null)
                { 
                   
                    equipoEncontrado.Municipio = municipioEncontrado;
                    _appContext.SaveChanges();
                }
                return municipioEncontrado;
            }
            return null;
        }

        Municipio IRepositorioEquipo.AsignarMunicipio(int idEquipo, int idMunicipio)
        {
            var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
            if (equipoEncontrado != null)
            { 
                var municipioEncontrado = _appContext.Municipios.Find(idMunicipio);
                if (municipioEncontrado != null)
                { 
                   
                    equipoEncontrado.Municipio = municipioEncontrado;
                    _appContext.SaveChanges();
                }
                return municipioEncontrado;
            }
            return null;
        }

    }



    
    
}