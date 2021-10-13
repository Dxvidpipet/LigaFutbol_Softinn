using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioEquipo
    {
        IEnumerable<Equipo> GetAllEquipos();
        Equipo CreateEquipo(Equipo equipo);
        Equipo ReadEquipo(int idEquipo);
        //Equipo UpdateEquipo(Equipo equipo);
        string DeleteEquipo(int idEquipo);
        Municipio AsignarMunicipio(int idEquipo, int idMunicipio);
        Municipio AsignarMunicipios(Equipo equipo, int idMunicipio);
        Municipio UpdateEquipo(Equipo equipo,int idEquipo, int idMunicipio);
        //IEnumerable<Equipo> GetEquipoFiltro(int filtro);
        IEnumerable<Equipo> SearchEquipoMuni(string nombreequipo,string nombremuni,string busqueda);
    }
}