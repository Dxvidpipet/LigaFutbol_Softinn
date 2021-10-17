using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioArbitro: IRepositorioArbitro
    {
        /*
        private readonly AppContext _appContext;

        public RepositorioArbitro(AppContext appContext)
        {
            _appContext = appContext;
        }
        */
        private readonly AppContext _appContext = new AppContext();

        IEnumerable<Arbitro> IRepositorioArbitro.GetAllArbitros()
        {
            return _appContext.Arbitros;
        }

        Arbitro IRepositorioArbitro.CreateArbitro(Arbitro arbitro)
        {
            var arbitroAdicionado = _appContext.Arbitros.Add(arbitro);
            _appContext.SaveChanges();
            return arbitroAdicionado.Entity;
        }

        Arbitro IRepositorioArbitro.ReadArbitro(int idArbitro)
        {
            var arbitroEncontrado = _appContext.Arbitros.FirstOrDefault(m => m.IdArbitro == idArbitro);
            return arbitroEncontrado;
        }

        Arbitro IRepositorioArbitro.UpdateArbitro(Arbitro arbitro)
        {
            var arbitroEncontrado = _appContext.Arbitros.FirstOrDefault(m => m.IdArbitro == arbitro.IdArbitro);
            if (arbitroEncontrado != null)
            {
                arbitroEncontrado.NombreArbitro = arbitro.NombreArbitro;
                arbitroEncontrado.DocumentoArbitro = arbitro.DocumentoArbitro;
                arbitroEncontrado.TelefonoArbitro = arbitro.TelefonoArbitro;
                arbitroEncontrado.ColegioArbitro = arbitro.ColegioArbitro;

                _appContext.SaveChanges();
            }
            
            return arbitroEncontrado;
        }

        string IRepositorioArbitro.DeleteArbitro(int idArbitro)
        {
            var arbitroEncontrado = _appContext.Arbitros.FirstOrDefault(m => m.IdArbitro == idArbitro);
            if (arbitroEncontrado == null)
                return "Arbitro no encontrado!";
            _appContext.Arbitros.Remove(arbitroEncontrado);
            _appContext.SaveChanges();
            return "Arbitro eliminado!";
        }
        IEnumerable<Arbitro> IRepositorioArbitro.SearchArbitros(string nombre)
        {
            return _appContext.Arbitros
                .Where(p => p.NombreArbitro.Contains(nombre));
        }
    }
}