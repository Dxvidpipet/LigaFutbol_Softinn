using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class RepositorioPartido: IRepositorioPartido
    {
        /*
        private readonly AppContext _appContext;

        public RepositorioPartido(AppContext appContext)
        {
            _appContext = appContext;
        }
        */
        private readonly AppContext _appContext = new AppContext();
        IEnumerable<Partido> IRepositorioPartido.GetAllPartidos()
        {
            return _appContext.Partidos
            .Include(p => p.NombreEquipoLocal)
            .Include(p => p.NombreEquipoVisitante)
            .Include(p => p.Arbitro)
            .Include(p => p.Estadio);
        }

    IEnumerable<Partido> IRepositorioPartido.SearchPartidoAll(string nombreall,int busqueda)
        {

          
             switch (busqueda)
            {
                case 0:
                    return _appContext.Partidos;
                case 1:
                    return _appContext.Partidos.Where(e => e.NombreEquipoLocal.NombreEquipo == nombreall );
                case 2:
                    return _appContext.Partidos.Where(e => e.NombreEquipoVisitante.NombreEquipo == nombreall);
                case 3:
                    return _appContext.Partidos.Where(e => e.Estadio.NombreEstadio == nombreall );
                case 4:
                    return _appContext.Partidos.Where(e => e.Arbitro.NombreArbitro == nombreall);
                default:
                    return _appContext.Partidos;
            }    
         
            // .Where(e => e.Equipo == (Equipo)nombre);
             //.Include(p => p.Municipio.Contains(nombre));
        }


        Partido IRepositorioPartido.ReadPartido(int IdPartido)
        {
           
             var partido = _appContext.Partidos
                        .Where(e => e.IdPartido == IdPartido)
                        .Include(p => p.Arbitro)
                        .Include(p => p.Estadio)
                        .Include(p => p.NombreEquipoLocal)
                        .Include(p => p.NombreEquipoVisitante)
                        .FirstOrDefault();
            return partido;
             
        }
        Partido IRepositorioPartido.CreatePartido(Partido partido)
        {
            var partidoAdicionado = _appContext.Partidos.Add(partido);
            _appContext.SaveChanges();
            return partidoAdicionado.Entity;
        }



        Partido IRepositorioPartido.UpdatePartido(Partido partido,int idPartido,int idEquipo,int idEquipoV, int idEstadio, int idArbitro)
        {
           
           var partidoEncontrado = _appContext.Partidos.Find(idPartido);
            if (partidoEncontrado != null)
            { 
                partidoEncontrado.FechaPartido =partido.FechaPartido;
                partidoEncontrado.MarcadorLocal =partido.MarcadorLocal;
                partidoEncontrado.MarcadorVisitante =partido.MarcadorVisitante;
                _appContext.SaveChanges();

                var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
                var equipoVEncontrado = _appContext.Equipos.Find(idEquipoV);
                var estadioEncontrado = _appContext.Estadios.Find(idEstadio);
                var arbitroEncontrado = _appContext.Arbitros.Find(idArbitro);


                if (equipoEncontrado != null)
                { 

                    partidoEncontrado.NombreEquipoLocal = equipoEncontrado;
                  
                    _appContext.SaveChanges();

                }

                if (equipoVEncontrado != null)
                { 
                    partidoEncontrado.NombreEquipoVisitante = equipoVEncontrado;
                  
                    _appContext.SaveChanges();  
                }

                if (estadioEncontrado != null)
                { 
                    partidoEncontrado.Estadio = estadioEncontrado;
                  
                    _appContext.SaveChanges(); 
                }
                 if (arbitroEncontrado != null)
                { 
                    partidoEncontrado.Arbitro = arbitroEncontrado;
                  
                    _appContext.SaveChanges(); 
                }

                
                    
                
                return partidoEncontrado;
            }
            return null;
        }











        /*Partido IRepositorioPartido.UpdatePartido(Partido partido)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(m => m.IdPartido == partido.IdPartido);
            if (partidoEncontrado != null)
            {
                partidoEncontrado.FechaPartido = partido.FechaPartido;
                partidoEncontrado.MarcadorLocal = partido.MarcadorLocal;
                partidoEncontrado.MarcadorVisitante = partido.MarcadorVisitante;
                _appContext.SaveChanges();
            }
            
            return partidoEncontrado;
        }*/


        Equipo IRepositorioPartido.AsignarEquipoLocal(int idPartido, int idEquipo)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.IdPartido == idPartido);
            if (partidoEncontrado != null)
            { 
                var equipoEncontrado = _appContext.Equipos.FirstOrDefault(e => e.IdEquipo == idEquipo);
                if (equipoEncontrado != null)
                { 
                    partidoEncontrado.NombreEquipoLocal = equipoEncontrado;
                    _appContext.SaveChanges();
                }
                return equipoEncontrado;
            }
            return null;
        }
          Equipo IRepositorioPartido.AsignarPartido(Partido partido, int idEquipo, int idEquipoV ,int idEstadio, int idArbitro)
        {


             Console.WriteLine(partido.FechaPartido);
            Console.WriteLine(partido.NombreEquipoLocal);
            Console.WriteLine(partido.NombreEquipoVisitante);
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.FechaPartido == partido.FechaPartido && p.NombreEquipoLocal == partido.NombreEquipoLocal && p.NombreEquipoVisitante == partido.NombreEquipoVisitante);
            var NombreLocalEncontrado = _appContext.Partidos.FirstOrDefault(p => p.NombreEquipoLocal == partido.NombreEquipoLocal);
            var NombreVEncontrado = _appContext.Partidos.FirstOrDefault(p => p.NombreEquipoVisitante == partido.NombreEquipoVisitante);
             Console.WriteLine(partidoEncontrado);
            Console.WriteLine(NombreLocalEncontrado.NombreEquipoLocal);
            Console.WriteLine(NombreLocalEncontrado.NombreEquipoVisitante);
            
            
           
            
            if (partidoEncontrado != null)
            { 
                Console.WriteLine(partidoEncontrado);
                var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
                var equipoVEncontrado = _appContext.Equipos.Find(idEquipoV);
                var estadioEncontrado = _appContext.Estadios.Find(idEstadio);
                var arbitroEncontrado = _appContext.Arbitros.Find(idArbitro);

                if (equipoEncontrado != null)
                { 
                   Console.WriteLine("AQUI"+equipoEncontrado);
                    partidoEncontrado.NombreEquipoLocal = equipoEncontrado;
                   Console.WriteLine("AQUIpa ver"+partidoEncontrado.NombreEquipoLocal);

                    _appContext.SaveChanges();
                }
                if (equipoVEncontrado != null)
                { 
                    Console.WriteLine("AQUI2"+equipoVEncontrado);
                    partidoEncontrado.NombreEquipoVisitante = equipoVEncontrado;
                   Console.WriteLine("AQUIpa ver2"+partidoEncontrado.NombreEquipoVisitante);
                    _appContext.SaveChanges();

                }

                

                if (estadioEncontrado != null)
                { 
                    partidoEncontrado.Estadio = estadioEncontrado;
                  
                    _appContext.SaveChanges(); 
                }
                 if (arbitroEncontrado != null)
                { 
                    partidoEncontrado.Arbitro = arbitroEncontrado;
                  
                    _appContext.SaveChanges(); 
                }
                return equipoEncontrado;
            }
            return null;
        }

        Equipo IRepositorioPartido.AsignarEquipoVisitante(int idPartido, int idEquipo)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.IdPartido == idPartido);
            if (partidoEncontrado != null)
            { 
                var equipoEncontrado = _appContext.Equipos.FirstOrDefault(e => e.IdEquipo == idEquipo);
                if (equipoEncontrado != null)
                { 
                    partidoEncontrado.NombreEquipoVisitante = equipoEncontrado;
                    _appContext.SaveChanges();
                }
                return equipoEncontrado;
            }
            return null;
        }
        Arbitro IRepositorioPartido.AsignarArbitro(int idPartido, int idArbitro)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.IdPartido == idPartido);
            if (partidoEncontrado != null)
            { 
                var arbitroEncontrado = _appContext.Arbitros.FirstOrDefault(a => a.IdArbitro == idArbitro);
                if (arbitroEncontrado != null)
                { 
                    partidoEncontrado.Arbitro = arbitroEncontrado;
                    _appContext.SaveChanges();
                }
                return arbitroEncontrado;
            }
            return null;
        }
        Estadio IRepositorioPartido.AsignarEstadio(int idPartido, int idEstadio)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.IdPartido == idPartido);
            if (partidoEncontrado != null)
            { 
                var estadioEncontrado = _appContext.Estadios.FirstOrDefault(e => e.IdEstadio == idEstadio);
                if (estadioEncontrado != null)
                { 
                    partidoEncontrado.Estadio = estadioEncontrado;
                    _appContext.SaveChanges();
                }
                return estadioEncontrado;
            }
            return null;
        }
    }
}