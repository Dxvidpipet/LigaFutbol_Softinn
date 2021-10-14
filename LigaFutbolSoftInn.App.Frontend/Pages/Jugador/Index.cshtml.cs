using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LigaFutbolSoftInn.App.Persistencia;
using LigaFutbolSoftInn.App.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace LigaFutbolSoftInn.App.Frontend.Pages
{
    [Authorize]
    public class IndexJugadorModel : PageModel
    {
     private readonly IRepositorioJugador _repoJugador;
        public IEnumerable<Jugador> jugadores {get; set;}
        public IndexJugadorModel(IRepositorioJugador repoJugador)
        {
            _repoJugador= repoJugador;
        }
        public void OnGet()
        {
            jugadores = _repoJugador.GetAllJugadores();
        }
    }
}
