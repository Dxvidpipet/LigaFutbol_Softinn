using System.Security.AccessControl;
using System.Collections.Generic;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public interface IRepositorioArbitro
    {
        IEnumerable<Arbitro> GetAllArbitros();
        Arbitro CreateArbitro(Arbitro arbitro);
        Arbitro ReadArbitro(int idArbitro);
        Arbitro UpdateArbitro(Arbitro arbitro);
        string DeleteArbitro(int idArbitro);
    }
}