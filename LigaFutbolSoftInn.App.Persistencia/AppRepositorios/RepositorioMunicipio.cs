using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioMunicipio: IRepositorioMunicipio
    {
        /*
        private readonly AppContext _appContext;

        public RepositorioMunicipio(AppContext appContext)
        {
            _appContext = appContext;
        }
        */
        private readonly AppContext _appContext = new AppContext();

        IEnumerable<Municipio> IRepositorioMunicipio.GetAllMunicipios()
        {
            return _appContext.Municipios;
        }

        Municipio IRepositorioMunicipio.CreateMunicipio(Municipio municipio)
        {
            var municipioAdicionado = _appContext.Municipios.Add(municipio);
            _appContext.SaveChanges();
            return municipioAdicionado.Entity;
        }

        Municipio IRepositorioMunicipio.ReadMunicipio(int idMunicipio)
        {
            var municipioEncontrado = _appContext.Municipios.FirstOrDefault(m => m.IdMunicipio == idMunicipio);
            return municipioEncontrado;
        }

        Municipio IRepositorioMunicipio.UpdateMunicipio(Municipio municipio)
        {
            var municipioEncontrado = _appContext.Municipios.FirstOrDefault(m => m.IdMunicipio == municipio.IdMunicipio);
            if (municipioEncontrado != null)
            {
                municipioEncontrado.NombreMunicipio = municipio.NombreMunicipio;

                _appContext.SaveChanges();
            }
            
            return municipioEncontrado;
        }

        string IRepositorioMunicipio.DeleteMunicipio(int idMunicipio)
        {
            var municipioEncontrado = _appContext.Municipios.FirstOrDefault(m => m.IdMunicipio == idMunicipio);
            if (municipioEncontrado == null)
                return "Municipio no encontrado!";
            _appContext.Municipios.Remove(municipioEncontrado);
            _appContext.SaveChanges();
            return "Municipio eliminado!";
        }
    }
}