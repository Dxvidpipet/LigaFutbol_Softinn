using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioEquipo: IRepositorioEquipo
    {
        private readonly AppContext _appContext;

        public RepositorioEquipo(AppContext appContext)
        {
            _appContext = appContext;
        }
        Equipo IRepositorioEquipo.CreateEquipo(Equipo equipo)
        {
            var equipoAdicionado = _appContext.Equipos.Add(equipo);
            _appContext.SaveChanges();
            return equipoAdicionado.Entity;
        }

        Equipo IRepositorioEquipo.ReadEquipo(int idEquipo)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(m => m.IdEquipo == idEquipo);
            return equipoEncontrado;
        }

        Equipo IRepositorioEquipo.UpdateEquipo(Equipo equipo)
        {
            var equipoEncontrado = _appContext.equipos.FirstOrDefault(m => m.IdEquipo == Equipo.IdEquipo);
            if (equipoEncontrado != null)
            {
                equipoEncontrado.NombreEquipo = equipo.NombreEquipo;

                _appContext.SaveChanges();
            }
            
            return equipoEncontrado;
        }

        string IRepositorioEquipo.DeleteEquipo(int idEquipo)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(m => m.IdEquipo == idEquipo);
            if (EquipoEncontrado == null)
                return "Equipo no encontrado!";
            _appContext.Equipos.Remove(equipoEncontrado);
            _appContext.SaveChanges();
            return "Equipo eliminado!";
        }
       

        Equipo IRepositorioEquipo.AsignarMunicipio(int idEquipo, int idMunicipio)
        {
            var EquipoEncontrado = _appContext.Equipos.FirstOrDefault(p => p.IdEquipo == idEquipo);
            if (EquipoEncontrado != null)
            { 
                var municipioEncontrado = _appContext.Municipio.FirstOrDefault(e => e.idMunicipio == idMunicipio);
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