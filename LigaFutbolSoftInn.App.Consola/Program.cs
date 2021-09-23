using System;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        private static IRepositorioNovedad _repoNovedad = new RepositorioNovedad(new Persistencia.AppContext());
        private static IRepositorioPartido _repoPartido = new RepositorioPartido(new Persistencia.AppContext());
        private static IRepositorioArbitro _repoArbitro = new RepositorioArbitro(new Persistencia.AppContext());
        
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

    }
}
