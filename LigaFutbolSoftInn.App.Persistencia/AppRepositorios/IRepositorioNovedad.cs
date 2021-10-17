using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioNovedad
    {
        IEnumerable<Novedad> GetAllNovedades();
        IEnumerable<Novedad> SearchNovedades(string tipo);
        Novedad CreateNovedad(Novedad novedad);
        Novedad ReadNovedad(int idNovedad);
        Novedad UpdateNovedad(Novedad novedad);
        Jugador AsignarJugador(int idNovedad, int idJugador);
        Partido AsignarPartido(int idNovedad, int idPartido);
        //IEnumerable<Novedad> GetNovedadesTipo(int tipo);
    }
}