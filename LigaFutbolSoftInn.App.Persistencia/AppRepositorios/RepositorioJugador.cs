using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioJugador: IRepositorioJugador
    {
        /*
        private readonly AppContext _appContext;

        public RepositorioJugador(AppContext appContext)
        {
            _appContext = appContext;
        }
        */
        private readonly AppContext _appContext = new AppContext();
        IEnumerable<Jugador> IRepositorioJugador.GetAllJugadores()
        {
            return _appContext.Jugadores
            .Include(p => p.Equipo);
        }

        Jugador IRepositorioJugador.CreateJugador(Jugador jugador)
        {
            var jugadorAdicionado = _appContext.Jugadores.Add(jugador);
            _appContext.SaveChanges();
            return jugadorAdicionado.Entity;
        }

        Jugador IRepositorioJugador.ReadJugador(int idJugador)
        {
            var Jugador = _appContext.Jugadores
                        .Where(e => e.IdJugador == idJugador)
                        .Include(m => m.Equipo)
                        .FirstOrDefault();

            return Jugador;
        }

        Jugador IRepositorioJugador.UpdateJugador(Jugador jugador)
        {
            var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(m => m.IdJugador == jugador.IdJugador);
            if (jugadorEncontrado != null)
            {
                jugadorEncontrado.NombreJugador = jugador.NombreJugador;
                jugadorEncontrado.NumeroJugador = jugador.NumeroJugador;
                jugadorEncontrado.PosicionJugador = jugador.PosicionJugador;

                _appContext.SaveChanges();
            }
            
            return jugadorEncontrado;
        }

        string IRepositorioJugador.DeleteJugador(int idJugador)
        {
            var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(m => m.IdJugador == idJugador);
            if (jugadorEncontrado == null)
                return "Jugador no encontrado!";
            _appContext.Jugadores.Remove(jugadorEncontrado);
            _appContext.SaveChanges();
            return "Jugador eliminado!";
        }
       

        Equipo IRepositorioJugador.AsignarJugadorEquipo(int idJugador, int idEquipo)
        {
            var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(p => p.IdJugador == idJugador);
            if (jugadorEncontrado != null)
            { 
                var equipoEncontrado = _appContext.Equipos.FirstOrDefault(e => e.IdEquipo == idEquipo);
                if (equipoEncontrado != null)
                { 
                    jugadorEncontrado.Equipo = equipoEncontrado;
                    _appContext.SaveChanges();
                }
                return equipoEncontrado;
            }
            return null;
        }
        IEnumerable<Jugador> IRepositorioJugador.SearchJugadores(string nombre)
        {
            return _appContext.Jugadores
                        .Where(p => p.NombreJugador.Contains(nombre));
        }

    }
}