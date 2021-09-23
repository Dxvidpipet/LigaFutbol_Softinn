using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioEquipo
    {
        Equipo CreateEquipo(Equipo equipo);
        Equipo ReadEquipo(int idEquipo);
        Equipo UpdateEquipo(Equipo equipo);
        string DeleteEquipo(int idEquipo);
        Municipio AsignarMunicipio(int idEquipo, int idMunicipio);
    }
}