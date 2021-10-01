using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioEstadio: IRepositorioEstadio
    {
    private readonly AppContext _appContext = new AppContext();
        IEnumerable<Estadio> IRepositorioEstadio.GetAllEstadios()
        {
            return _appContext.Estadios;
        }
        /*
        private readonly AppContext _appContext;

        public RepositorioEstadio(AppContext appContext)
        {
            return _appContext.Estadios;
        }
        */

        Estadio IRepositorioEstadio.CreateEstadio(Estadio estadio)
        {
            var estadioAdicionado = _appContext.Estadios.Add(estadio);
            _appContext.SaveChanges();
            return estadioAdicionado.Entity;
        }

        Estadio IRepositorioEstadio.ReadEstadio(int idEstadio)
        {
            var estadioEncontrado = _appContext.Estadios.FirstOrDefault(m => m.IdEstadio == idEstadio);
            return estadioEncontrado;
        }

        Estadio IRepositorioEstadio.UpdateEstadio(Estadio estadio)
        {
            var estadioEncontrado = _appContext.Estadios.FirstOrDefault(m => m.IdEstadio == estadio.IdEstadio);
            if (estadioEncontrado != null)
            {
                estadioEncontrado.NombreEstadio = estadio.NombreEstadio;
                estadioEncontrado.DireccionEstadio = estadio.DireccionEstadio;

                _appContext.SaveChanges();
            }
            
            return estadioEncontrado;
        }

        string IRepositorioEstadio.DeleteEstadio(int idEstadio)
        {
            var estadioEncontrado = _appContext.Estadios.FirstOrDefault(m => m.IdEstadio == idEstadio);
            if (estadioEncontrado == null)
                return "Estadio no encontrado!";
            _appContext.Estadios.Remove(estadioEncontrado);
            _appContext.SaveChanges();
            return "Estadio eliminado!";
        }
       

        Municipio IRepositorioEstadio.AsignarEstadioMunicipio(int idEstadio, int idMunicipio)
        {
            var estadioEncontrado = _appContext.Estadios.FirstOrDefault(p => p.IdEstadio == idEstadio);
            if (estadioEncontrado != null)
            { 
                var municipioEncontrado = _appContext.Municipios.FirstOrDefault(e => e.IdMunicipio == idMunicipio);
                if (municipioEncontrado != null)
                { 
                    estadioEncontrado.Municipio = municipioEncontrado;
                    _appContext.SaveChanges();
                }
                return municipioEncontrado;
            }
            return null;
        }

    }
}