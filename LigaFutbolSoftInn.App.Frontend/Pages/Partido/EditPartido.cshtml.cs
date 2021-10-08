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
    public class EditPartidoModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioArbitro _repoArbitro;
        private readonly IRepositorioEstadio _repoEstadio;
        public Partido partido { get; set; }
        public IEnumerable<Municipio> municipios { get; set; }
        public IEnumerable<Equipo> equiposLocal { get; set; }
        public IEnumerable<Equipo> equiposVisitante { get; set; }
        public IEnumerable<Arbitro> arbitros { get; set; }
        public IEnumerable<Estadio> estadios { get; set; }
        public EditPartidoModel(IRepositorioPartido repoPartido,IRepositorioEquipo repoEquipo,IRepositorioArbitro repoArbitro,IRepositorioEstadio repoEstadio)
        {
            _repoPartido = repoPartido;
            _repoEquipo =  repoEquipo;
            _repoArbitro = repoArbitro;
            _repoEstadio = repoEstadio;
        }

        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.ReadPartido(id);
            equiposLocal =  _repoEquipo.GetAllEquipos();
            equiposVisitante =  _repoEquipo.GetAllEquipos();
            arbitros = _repoArbitro.GetAllArbitros();
            estadios = _repoEstadio.GetAllEstadios();
            if (partido == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Partido partido,int idPartido,int idEquipo,int idEquipoV, int idEstadio, int idArbitro)
        {
            
            _repoPartido.UpdatePartido(partido,idPartido,idEquipo,idEquipoV,idEstadio,idArbitro);
            return RedirectToPage("IndexPartido");
        }
    }
}
