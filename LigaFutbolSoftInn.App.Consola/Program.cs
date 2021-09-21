using System;
using LigaFutbolSoftInn.App.Dominio;
using LigaFutbolSoftInn.App.Persistencia;

namespace LigaFutbolSoftInn.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to LigaFutbolSoftInn!");
            //CreateMunicipio();
            //UpdateMunicipio();
            //ReadMunicipio(1);
            DeleteMunicipio(1);
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
    }
}
