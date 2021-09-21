using Microsoft.EntityFrameworkCore;
using LigaFutbolSoftInn.App.Dominio;

namespace LigaFutbolSoftInn.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Arbitro> Abitros { get; set; }
        public DbSet<DirTecnico> DirTecnicos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Novedad> Novedades { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = LigaFutbolSoftInnData");
            }
        }
    }
}