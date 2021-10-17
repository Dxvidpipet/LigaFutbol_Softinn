using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioNovedad : IRepositorioNovedad
    {
        /*
        private readonly AppContext _appContext;

        public RepositorioNovedad(AppContext appContext)
        {
            _appContext = appContext;
        }
        */

        private readonly AppContext _appContext = new AppContext();
        IEnumerable<Novedad> IRepositorioNovedad.GetAllNovedades()
        {
            return _appContext.Novedades
            .Include(p => p.Jugador)
            .Include(p => p.Partido);
        }

        Novedad IRepositorioNovedad.CreateNovedad(Novedad novedad)
        {
            var novedadAdicionada = _appContext.Novedades.Add(novedad);
            _appContext.SaveChanges();
            return novedadAdicionada.Entity;
        }
        Novedad IRepositorioNovedad.ReadNovedad(int idNovedad)
        {
            var novedad = _appContext.Novedades
                        .Where(e => e.IdNovedad == idNovedad)
                        .Include(p => p.Jugador)
                        .Include(p => p.Partido)
                        .FirstOrDefault();
            return novedad;
        }

        Novedad IRepositorioNovedad.UpdateNovedad(Novedad novedad)
        {
            var novedadEncontrado = _appContext.Novedades.FirstOrDefault(m => m.IdNovedad == novedad.IdNovedad);
            if (novedadEncontrado != null)
            {
                novedadEncontrado.TipoNovedad = novedad.TipoNovedad;
                novedadEncontrado.MinutoPartidoNovedad = novedad.MinutoPartidoNovedad;
                novedadEncontrado.Jugador = novedad.Jugador;

                _appContext.SaveChanges();
            }

            return novedadEncontrado;
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
        IEnumerable<Novedad> IRepositorioNovedad.SearchNovedades(string tipo)
        {
            return _appContext.Novedades
                        .Where(p => p.TipoNovedad1.Contains (tipo));
                        
        }

    }
}