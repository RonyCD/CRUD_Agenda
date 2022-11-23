using CRUDAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDAgenda.Datos
{
    public class AgendaDBContext : DbContext
    {
        //constructor
        public AgendaDBContext(DbContextOptions<AgendaDBContext> options) : base(options) { }


        // Modelos que se agregan
        public DbSet<Contacto> Contacto { get; set; }

    }
}
