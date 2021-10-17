using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioJugador
    {
        IEnumerable<Jugador> GetAllJugadores();
        IEnumerable<Jugador> SearchJugadores(string nombre);
        Jugador CreateJugador(Jugador jugador);
        Jugador ReadJugador(int idJugador);
        Jugador UpdateJugador(Jugador jugador);
        string DeleteJugador(int idJugador);
        Equipo AsignarJugadorEquipo(int idJugador, int idEquipo);
    }
}