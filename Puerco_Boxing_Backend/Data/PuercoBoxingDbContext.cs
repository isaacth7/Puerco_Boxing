using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Puerco_Boxing_Backend.Models;
namespace Puerco_Boxing_Backend.Data
{
    public class PuercoBoxingDbContext : DbContext 
    {
        public PuercoBoxingDbContext(DbContextOptions<PuercoBoxingDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Clase> Clases { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        //public DbSet<Reserva> Reservas { get; set; }
    }
}
