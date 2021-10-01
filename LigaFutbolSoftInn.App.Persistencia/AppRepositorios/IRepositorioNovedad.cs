using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioNovedad
    {
        IEnumerable<Novedad> GetAllNovedades();
        Novedad CreateNovedad(Novedad novedad);
        Novedad ReadNovedad(int idNovedad);
        Jugador AsignarJugador(int idNovedad, int idJugador);
        Partido AsignarPartido(int idNovedad, int idPartido);
    }
}