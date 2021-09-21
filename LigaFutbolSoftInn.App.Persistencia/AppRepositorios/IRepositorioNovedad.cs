using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioNovedad
    {
        Novedad CreateNovedad(Novedad novedad);
        Jugador AsignarJugador(int idNovedad, int idJugador);
        Partido AsignarPartido(int idNovedad, int idPartido);
    }
}