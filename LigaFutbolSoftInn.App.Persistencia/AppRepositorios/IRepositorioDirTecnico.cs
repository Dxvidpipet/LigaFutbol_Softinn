using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioDirTecnico
    {
        IEnumerable<DirTecnico> GetAllDirTecnicos();
        DirTecnico CreateDirTecnico(DirTecnico dirTecnico);
        DirTecnico ReadDirTecnico(int idDirTecnico);
        DirTecnico UpdateDirTecnico(DirTecnico dirTecnico);
        string DeleteDirTecnico(int idDirTecnico);
        Equipo AsignarDirTecnicoEquipo(int idDirTecnico, int idEquipo);
        IEnumerable<DirTecnico> SearchDirTecnicos(string nombre);
    }
}