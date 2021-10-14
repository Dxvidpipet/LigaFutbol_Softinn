using System.Collections;
using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioMunicipio
    {
        IEnumerable<Municipio> GetAllMunicipios();
        IEnumerable<Municipio> SearchMunicipios(string nombre);
        Municipio CreateMunicipio(Municipio municipio);
        Municipio ReadMunicipio(int idMunicipio);
        Municipio UpdateMunicipio(Municipio municipio);
        string DeleteMunicipio(int idMunicipio);
    }
}