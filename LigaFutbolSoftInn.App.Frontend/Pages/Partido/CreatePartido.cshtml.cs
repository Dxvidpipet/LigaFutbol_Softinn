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
    public class CreatePartidoModel : PageModel
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
        public CreatePartidoModel(IRepositorioPartido repoPartido,IRepositorioEquipo repoEquipo,IRepositorioArbitro repoArbitro,IRepositorioEstadio repoEstadio)
        {
            _repoPartido = repoPartido;
            _repoEquipo =  repoEquipo;
            _repoArbitro = repoArbitro;
            _repoEstadio = repoEstadio;
        }

        public void OnGet()
        {
            partido = new Partido();
            equiposLocal =  _repoEquipo.GetAllEquipos();
            equiposVisitante =  _repoEquipo.GetAllEquipos();
            arbitros = _repoArbitro.GetAllArbitros();
            estadios = _repoEstadio.GetAllEstadios();
        }

        public IActionResult OnPost(Partido partido, int idEquipo, int idEquipoV ,int idEstadio, int idArbitro)
        {
            if (ModelState.IsValid)
            {
                _repoPartido.CreatePartido(partido);

                _repoPartido.AsignarPartido(partido, idEquipo,idEquipoV,idEstadio,idArbitro);
                //_repoEquipo.AsignarEquipoVisitante(partido, idEquipo);
               // _repoEquipo.AsignarArbitro(partido, idArbitro);
                //_repoEquipo.AsignarEstadio(partido, idEstadio);
                return RedirectToPage("IndexPartido");
            }
            else
            {
            equiposLocal =  _repoEquipo.GetAllEquipos();
            equiposVisitante =  _repoEquipo.GetAllEquipos();
            arbitros = _repoArbitro.GetAllArbitros();
            estadios = _repoEstadio.GetAllEstadios();
            return Page();
            }
        }
    }
}
