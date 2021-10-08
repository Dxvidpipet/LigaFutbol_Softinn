using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioPartido
    {
        IEnumerable<Partido> GetAllPartidos();
        Partido CreatePartido(Partido partido);
        Partido ReadPartido(int idPartido);
        Partido UpdatePartido(Partido partido,int idPartido,int idEquipo,int idEquipoV, int idEstadio, int idArbitro);
        /*Partido UpdatePartido(Partido partido);*/
        Equipo AsignarEquipoLocal(int idPartido, int idEquipo);
        Equipo AsignarPartido(Partido partido, int idEquipo, int idEquipoV ,int idEstadio, int idArbitro);
        Equipo AsignarEquipoVisitante(int idPartido, int idEquipo);
        Arbitro AsignarArbitro(int idPartido, int idArbitro);
        Estadio AsignarEstadio(int idPartido, int idEstadio);
    }
}