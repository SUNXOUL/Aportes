using Microsoft.EntityFrameworkCore;
using Aportes.Shared.Models;

namespace Aportes.Server.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> Options) : base(Options) { }

        public DbSet<Aporte> Aportes { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<TiposAportes> TiposAportes { get; set; }
    }
}
