using System;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Consola
{
    class Program
    {
        //private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        //private static IRepositorioNovedad _repoNovedad = new RepositorioNovedad(new Persistencia.AppContext());
        //private static IRepositorioPartido _repoPartido = new RepositorioPartido(new Persistencia.AppContext());
        //private static IRepositorioArbitro _repoArbitro = new RepositorioArbitro(new Persistencia.AppContext());
        //private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo(new Persistencia.AppContext());
        //private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio(new Persistencia.AppContext());
        //private static IRepositorioDirTecnico _repoDirTecnico = new RepositorioDirTecnico(new Persistencia.AppContext());
        //private static IRepositorioJugador _repoJugador = new RepositorioJugador(new Persistencia.AppContext());
        
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioNovedad _repoNovedad = new RepositorioNovedad();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();
        private static IRepositorioArbitro _repoArbitro = new RepositorioArbitro();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio();
        private static IRepositorioDirTecnico _repoDirTecnico = new RepositorioDirTecnico();
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();

        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to LigaFutbolSoftInn!");
            //CreateMunicipio();
            //UpdateMunicipio();
            //ReadMunicipio(1);
            //DeleteMunicipio(1);
            //CreateNovedad();
            //CreatePartido();
            //AsignarPartido(1, 1);
            //GetAllArbitros();
            //CreateArbitro();
            //UpdateArbitro();
            //ReadArbitro(1);
            //DeleteArbitro(1);
            //CreateEquipo();
            //UpdateEquipo();
            ReadEquipo(1);
            //DeleteEquipo(1);
            //AsignarMunicipio(2, 2);
            //CreateEstadio();
            //UpdateEstadio();
            //ReadEstadio(1);
            //DeleteEstadio(1);
            //AsignarEstadioMunicipio(2, 2);
            //CreateDirTecnico();
            //UpdateDirTecnico();
            //ReadDirTecnico(1);
            //DeleteDirTecnico(1);
            //AsignarDirTecnicoEquipo(2, 2);
            //CreateJugador();
            //UpdateJugador();
            //ReadJugador(1);
            //DeleteJugador(1);
            //AsignarJugadorEquipo(2, 2);
        }

        private static void CreateMunicipio()
        {
            var municipio = new Municipio
            {
                NombreMunicipio = "Bogotá"
            };
            _repoMunicipio.CreateMunicipio(municipio);
        }

        private static void UpdateMunicipio()
        {
            var municipio = new Municipio
            {
                IdMunicipio = 1,
                NombreMunicipio = "Cartagena"
            };
            _repoMunicipio.UpdateMunicipio(municipio);
        }

        private static void ReadMunicipio(int idMunicipio)
        {
            var municipio = _repoMunicipio.ReadMunicipio(idMunicipio);
            Console.WriteLine(municipio.NombreMunicipio);
        }

        private static void DeleteMunicipio(int idMunicipio)
        {
            string mensaje = _repoMunicipio.DeleteMunicipio(idMunicipio);
            Console.WriteLine(mensaje);
        }

        private static void CreateNovedad()
        {
            var novedad = new Novedad
            {
                TipoNovedad = TipoNovedad.Goles,
                MinutoPartidoNovedad = 15,
            };
            _repoNovedad.CreateNovedad(novedad);
        }

        private static void AsignarJugador(int idNovedad, int idJugador)
        {
            var jugador = _repoNovedad.AsignarJugador(idNovedad, idJugador);
            Console.WriteLine(jugador.NombreJugador+" "+jugador.NumeroJugador);
        }

        private static void AsignarPartido(int idNovedad, int idPartido)
        {
            var partido = _repoNovedad.AsignarPartido(idNovedad, idPartido);
            Console.WriteLine(partido.NombreEquipoLocal+" vs "+partido.NombreEquipoVisitante);
        }

        private static void CreatePartido()
        {
            var partido = new Partido
            {
                FechaPartido = new DateTime(2021, 09, 22),
                MarcadorLocal = 1,
                MarcadorVisitante = 2
            };
            _repoPartido.CreatePartido(partido);
        }

        private static void AsignarEquipoLocal(int idPartido, int idEquipo)
        {
            var equipo = _repoPartido.AsignarEquipoLocal(idPartido, idEquipo);
            Console.WriteLine(equipo.NombreEquipo);
        }

        private static void AsignarEquipoVisitante(int idPartido, int idEquipo)
        {
            var equipo = _repoPartido.AsignarEquipoVisitante(idPartido, idEquipo);
            Console.WriteLine(equipo.NombreEquipo);
        }

        private static void AsignarArbitro(int idPartido, int idArbitro)
        {
            var arbitro = _repoPartido.AsignarArbitro(idPartido, idArbitro);
            Console.WriteLine(arbitro.NombreArbitro);
        }

        private static void AsignarEstadio(int idPartido, int idEstadio)
        {
            var estadio = _repoPartido.AsignarEstadio(idPartido, idEstadio);
            Console.WriteLine(estadio.NombreEstadio);
        }

        private static void GetAllArbitros()
        {
            var arbitros = _repoArbitro.GetAllArbitros();
            foreach (var a in arbitros)
            {
                Console.WriteLine(a.NombreArbitro+" "+a.ColegioArbitro);
            }
        }

        private static void CreateArbitro()
        {
            var arbitro = new Arbitro
            {
                NombreArbitro = "Oscar Julian Ruiz",
                DocumentoArbitro = "1032789456",
                TelefonoArbitro = "3124567852",
                ColegioArbitro = "Colegio Mayor de Arbitros"
            };
            _repoArbitro.CreateArbitro(arbitro);
        }

        private static void UpdateArbitro()
        {
            var arbitro = new Arbitro
            {
                IdArbitro = 1,
                NombreArbitro = "Wilmar Roldan",
                DocumentoArbitro = "10324789456",
                TelefonoArbitro = "3134567852",
                ColegioArbitro = "Arbitros Unidos"
            };
            _repoArbitro.UpdateArbitro(arbitro);
        }

        private static void ReadArbitro(int idArbitro)
        {
            var arbitro = _repoArbitro.ReadArbitro(idArbitro);
            Console.WriteLine(arbitro.NombreArbitro);
        }

        private static void DeleteArbitro(int idArbitro)
        {
            string mensaje = _repoArbitro.DeleteArbitro(idArbitro);
            Console.WriteLine(mensaje);
        }

        private static void CreateEquipo()
        {
            var equipo = new Equipo
            {
                NombreEquipo = "Deportivo Tapitas"
            };
            _repoEquipo.CreateEquipo(equipo);
        }

        private static void UpdateEquipo()
        {
            var equipo = new Equipo
            {
                IdEquipo = 2,
                NombreEquipo = "Real Cartagena"
            };
            _repoEquipo.UpdateEquipo(equipo);
        }

        private static void ReadEquipo(int idEquipo)
        {
            var equipo = _repoEquipo.ReadEquipo(idEquipo);
            Console.WriteLine(equipo.NombreEquipo);
            Console.WriteLine(equipo.Municipio);
            if (equipo.Municipio==null)
            {
             Console.WriteLine("VACIO");
            }
           
        }

        private static void DeleteEquipo(int idEquipo)
        {
            string mensaje = _repoEquipo.DeleteEquipo(idEquipo);
            Console.WriteLine(mensaje);
        }

        private static void AsignarMunicipio(int idEquipo, int idMunicipio)
        {
            var municipio = _repoEquipo.AsignarMunicipio(idEquipo, idMunicipio);

            Console.WriteLine(municipio.NombreMunicipio);
        }

        private static void CreateEstadio()
        {
            var estadio = new Estadio
            {
                NombreEstadio = "Allianz Arena",
                DireccionEstadio = "Calle 52 # 13-15"
            };
            _repoEstadio.CreateEstadio(estadio);
        }

        private static void UpdateEstadio()
        {
            var estadio = new Estadio
            {
                IdEstadio = 1,
                NombreEstadio = "Campnou",
                DireccionEstadio = "Carrera 45 # 14-15"
            };
            _repoEstadio.UpdateEstadio(estadio);
        }

        private static void ReadEstadio(int idEstadio)
        {
            var estadio = _repoEstadio.ReadEstadio(idEstadio);
            Console.WriteLine(estadio.NombreEstadio);
        }

        private static void DeleteEstadio(int idEstadio)
        {
            string mensaje = _repoEstadio.DeleteEstadio(idEstadio);
            Console.WriteLine(mensaje);
        }

        private static void AsignarEstadioMunicipio(int idEstadio, int idMunicipio)
        {
            var municipio = _repoEstadio.AsignarEstadioMunicipio(idEstadio, idMunicipio);
            Console.WriteLine(municipio.NombreMunicipio);
        }

        private static void CreateDirTecnico()
        {
            var dirTecnico = new DirTecnico
            {
                NombreDirTecnico = "Jose Nestor Pekerman",
                DocumentoDirTecnico = "1035456875",
                TelefonoDirTecnico = "3155486285"
            };
            _repoDirTecnico.CreateDirTecnico(dirTecnico);
        }

        private static void UpdateDirTecnico()
        {
            var dirTecnico = new DirTecnico
            {
                IdDirTecnico = 1,
                NombreDirTecnico = "Amaranto Perea",
                DocumentoDirTecnico = "1033456875",
                TelefonoDirTecnico = "3165486285"
            };
            _repoDirTecnico.UpdateDirTecnico(dirTecnico);
        }

        private static void ReadDirTecnico(int idDirTecnico)
        {
            var dirTecnico = _repoDirTecnico.ReadDirTecnico(idDirTecnico);
            Console.WriteLine(dirTecnico.NombreDirTecnico);
        }

        private static void DeleteDirTecnico(int idDirTecnico)
        {
            string mensaje = _repoDirTecnico.DeleteDirTecnico(idDirTecnico);
            Console.WriteLine(mensaje);
        }

        private static void AsignarDirTecnicoEquipo(int idDirTecnico, int idEquipo)
        {
            var equipo = _repoDirTecnico.AsignarDirTecnicoEquipo(idDirTecnico, idEquipo);
            Console.WriteLine(equipo.NombreEquipo);
        }

        private static void CreateJugador()
        {
            var jugador = new Jugador
            {
                NombreJugador = "James Rodriguez",
                NumeroJugador = 10,
                PosicionJugador = "Mediocampista"
            };
            _repoJugador.CreateJugador(jugador);
        }

        private static void UpdateJugador()
        {
            var jugador = new Jugador
            {
                IdJugador = 1,
                NombreJugador = "Radamel Falcao Garcia",
                NumeroJugador = 9,
                PosicionJugador = "Delantero Centro"
            };
            _repoJugador.UpdateJugador(jugador);
        }

        private static void ReadJugador(int idJugador)
        {
            var jugador = _repoJugador.ReadJugador(idJugador);
            Console.WriteLine(jugador.NombreJugador);
        }

        private static void DeleteJugador(int idJugador)
        {
            string mensaje = _repoJugador.DeleteJugador(idJugador);
            Console.WriteLine(mensaje);
        }

        private static void AsignarJugadorEquipo(int idJugador, int idEquipo)
        {
            var equipo = _repoJugador.AsignarJugadorEquipo(idJugador, idEquipo);
            Console.WriteLine(equipo.NombreEquipo);
        }
    }
}
