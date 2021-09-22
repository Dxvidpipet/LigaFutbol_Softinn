using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioPartido: IRepositorioPartido
    {
        private readonly AppContext _appContext;

        public RepositorioPartido(AppContext appContext)
        {
            _appContext = appContext;
        }

        Partido IRepositorioPartido.CreatePartido(Partido partido)
        {
            var partidoAdicionado = _appContext.Partidos.Add(partido);
            _appContext.SaveChanges();
            return partidoAdicionado.Entity;
        }

        Equipo IRepositorioPartido.AsignarEquipoLocal(int idPartido, int idEquipo)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.IdPartido == idPartido);
            if (partidoEncontrado != null)
            { 
                var equipoEncontrado = _appContext.Equipos.FirstOrDefault(e => e.IdEquipo == idEquipo);
                if (equipoEncontrado != null)
                { 
                    partidoEncontrado.NombreEquipoLocal = equipoEncontrado;
                    _appContext.SaveChanges();
                }
                return equipoEncontrado;
            }
            return null;
        }

        Equipo IRepositorioPartido.AsignarEquipoVisitante(int idPartido, int idEquipo)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.IdPartido == idPartido);
            if (partidoEncontrado != null)
            { 
                var equipoEncontrado = _appContext.Equipos.FirstOrDefault(e => e.IdEquipo == idEquipo);
                if (equipoEncontrado != null)
                { 
                    partidoEncontrado.NombreEquipoVisitante = equipoEncontrado;
                    _appContext.SaveChanges();
                }
                return equipoEncontrado;
            }
            return null;
        }
        Arbitro IRepositorioPartido.AsignarArbitro(int idPartido, int idArbitro)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.IdPartido == idPartido);
            if (partidoEncontrado != null)
            { 
                var arbitroEncontrado = _appContext.Abitros.FirstOrDefault(a => a.IdArbitro == idArbitro);
                if (arbitroEncontrado != null)
                { 
                    partidoEncontrado.Arbitro = arbitroEncontrado;
                    _appContext.SaveChanges();
                }
                return arbitroEncontrado;
            }
            return null;
        }
        Estadio IRepositorioPartido.AsignarEstadio(int idPartido, int idEstadio)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.IdPartido == idPartido);
            if (partidoEncontrado != null)
            { 
                var estadioEncontrado = _appContext.Estadios.FirstOrDefault(e => e.IdEstadio == idEstadio);
                if (estadioEncontrado != null)
                { 
                    partidoEncontrado.Estadio = estadioEncontrado;
                    _appContext.SaveChanges();
                }
                return estadioEncontrado;
            }
            return null;
        }
    }
}