using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioEstadio
    {
        Estadio CreateEstadio(Estadio estadio);
        IEnumerable<Estadio> GetAllEstadios();
        IEnumerable<Estadio> SearchEstadios(string nombre);
        Estadio ReadEstadio(int idEstadio);
        Estadio UpdateEstadio(Estadio estadio);
        string DeleteEstadio(int idEstadio);
        Municipio AsignarEstadioMunicipio(int idEstadio, int idMunicipio);
    }
}