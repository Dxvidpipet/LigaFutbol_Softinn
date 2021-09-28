using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioNovedad: IRepositorioNovedad
    {
        /*
        private readonly AppContext _appContext;

        public RepositorioNovedad(AppContext appContext)
        {
            _appContext = appContext;
        }
        */

        private readonly AppContext _appContext = new AppContext();

        Novedad IRepositorioNovedad.CreateNovedad(Novedad novedad)
        {
            var novedadAdicionada = _appContext.Novedades.Add(novedad);
            _appContext.SaveChanges();
            return novedadAdicionada.Entity;
        }

        Jugador IRepositorioNovedad.AsignarJugador(int idNovedad, int idJugador)
        { 
            var novedadEncontrada = _appContext.Novedades.FirstOrDefault(n => n.IdNovedad == idNovedad);
            if (novedadEncontrada != null)
            { 
                var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(j => j.IdJugador == idJugador);
                if (jugadorEncontrado != null)
                { 
                    novedadEncontrada.Jugador = jugadorEncontrado;
                    _appContext.SaveChanges();
                }
                return jugadorEncontrado;
            }
            return null;
        }

        Partido IRepositorioNovedad.AsignarPartido(int idNovedad, int idPartido)
        {
            var novedadEncontrada = _appContext.Novedades.FirstOrDefault(n => n.IdNovedad == idNovedad);
            if (novedadEncontrada != null)
            {
                var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.IdPartido == idPartido);
                if (partidoEncontrado != null)
                {
                    novedadEncontrada.Partido = partidoEncontrado;
                    _appContext.SaveChanges();
                }
                return partidoEncontrado;
            }
            return null;
        }
    }
}