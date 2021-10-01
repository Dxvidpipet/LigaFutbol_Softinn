using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioDirTecnico: IRepositorioDirTecnico
    {
        /*
        private readonly AppContext _appContext;

        public RepositorioDirTecnico(AppContext appContext)
        {
            _appContext = appContext;
        }
        */

        private readonly AppContext _appContext = new AppContext();

<<<<<<< HEAD
=======
        IEnumerable<DirTecnico> IRepositorioDirTecnico.GetAllDirTecnicos()
        {
            return _appContext.DirTecnicos;
        }

>>>>>>> 35b4542d87f56fde011a5bb81b8a7ac836b3e3cf
        DirTecnico IRepositorioDirTecnico.CreateDirTecnico(DirTecnico dirTecnico)
        {
            var dirTecnicoAdicionado = _appContext.DirTecnicos.Add(dirTecnico);
            _appContext.SaveChanges();
            return dirTecnicoAdicionado.Entity;
        }

        DirTecnico IRepositorioDirTecnico.ReadDirTecnico(int idDirTecnico)
        {
            var dirTecnicoEncontrado = _appContext.DirTecnicos.FirstOrDefault(m => m.IdDirTecnico == idDirTecnico);
            return dirTecnicoEncontrado;
        }

        DirTecnico IRepositorioDirTecnico.UpdateDirTecnico(DirTecnico dirTecnico)
        {
            var dirTecnicoEncontrado = _appContext.DirTecnicos.FirstOrDefault(m => m.IdDirTecnico == dirTecnico.IdDirTecnico);
            if (dirTecnicoEncontrado != null)
            {
                dirTecnicoEncontrado.NombreDirTecnico = dirTecnico.NombreDirTecnico;
                dirTecnicoEncontrado.DocumentoDirTecnico = dirTecnico.DocumentoDirTecnico;
                dirTecnicoEncontrado.TelefonoDirTecnico = dirTecnico.TelefonoDirTecnico;

                _appContext.SaveChanges();
            }
            
            return dirTecnicoEncontrado;
        }

        string IRepositorioDirTecnico.DeleteDirTecnico(int idDirTecnico)
        {
            var dirTecnicoEncontrado = _appContext.DirTecnicos.FirstOrDefault(m => m.IdDirTecnico == idDirTecnico);
            if (dirTecnicoEncontrado == null)
                return "DirTecnico no encontrado!";
            _appContext.DirTecnicos.Remove(dirTecnicoEncontrado);
            _appContext.SaveChanges();
            return "DirTecnico eliminado!";
        }
       

        Equipo IRepositorioDirTecnico.AsignarDirTecnicoEquipo(int idDirTecnico, int idEquipo)
        {
            var dirTecnicoEncontrado = _appContext.DirTecnicos.FirstOrDefault(p => p.IdDirTecnico == idDirTecnico);
            if (dirTecnicoEncontrado != null)
            { 
                var equipoEncontrado = _appContext.Equipos.FirstOrDefault(e => e.IdEquipo == idEquipo);
                if (equipoEncontrado != null)
                { 
                    dirTecnicoEncontrado.Equipo = equipoEncontrado;
                    _appContext.SaveChanges();
                }
                return equipoEncontrado;
            }
            return null;
        }

    }
}