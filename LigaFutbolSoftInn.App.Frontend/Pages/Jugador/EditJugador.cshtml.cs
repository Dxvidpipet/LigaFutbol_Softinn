using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Frontend.Pages
{
    public class EditJugadorModel : PageModel
    {
        private readonly IRepositorioJugador _repoJugador;
        public Jugador jugador {get;set;}
        public EditJugadorModel (IRepositorioJugador repoJugador)
        {
            _repoJugador = repoJugador;
        }
        public IActionResult OnGet(int id)
        {
            jugador = _repoJugador.ReadJugador(id);
            if (jugador == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Jugador jugador)
        {
            _repoJugador.UpdateJugador(jugador);
            return RedirectToPage("Index");
        }
    }
}
