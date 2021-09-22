using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioPartido
    {
        Partido CreatePartido(Partido partido);
        Equipo AsignarEquipoLocal(int idPartido, int idEquipo);
        Equipo AsignarEquipoVisitante(int idPartido, int idEquipo);
        Arbitro AsignarArbitro(int idPartido, int idArbitro);
        Estadio AsignarEstadio(int idPartido, int idEstadio);
    }
}