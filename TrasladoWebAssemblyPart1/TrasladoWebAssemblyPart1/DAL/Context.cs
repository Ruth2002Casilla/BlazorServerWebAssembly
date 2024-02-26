using Microsoft.EntityFrameworkCore;
using TrasladoWebAssemblyPart1.Models;

namespace TrasladoWebAssemblyPart1.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options) : base(options){ }    

       public DbSet<Tickets> Tickets { get; set; }
       public  DbSet<TicketsDetalles> TicketsDetalles { get;set; }

    }
}
