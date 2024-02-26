using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrasladoWebAssemblyPart1.DAL;
using TrasladoWebAssemblyPart1.Models;

namespace TrasladoWebAssemblyPart1.Services
{
    public class TicketsDetalleService
    {
        private readonly Context _context;

        public TicketsDetalleService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int TicketId)
        {
            return await _context.TicketsDetalles.AnyAsync(t => t.TicketId == TicketId);
        }

        public async Task<bool> Agregar(TicketsDetalles Ticket)
        {
            _context.TicketsDetalles.Add(Ticket);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(TicketsDetalles Ticket)
        {
            _context.Update(Ticket);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(TicketsDetalles Ticket)
        {
            if (!await Verificar(Ticket.TicketId))
                return await Agregar(Ticket);
            else
                return await Modificar(Ticket);
        }

        public async Task<bool> Eliminar(TicketsDetalles Ticket)
        {
            var cantidad = await _context.Tickets
                .Where(t => t.TicketId == Ticket.TicketId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Tickets?> Buscar(int TicketId)
        {
            return await _context.Tickets
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TicketId == TicketId);
        }

        public async Task<List<TicketsDetalles>> Listar(Expression<Func<TicketsDetalles, bool>> criterio)
        {
            return await _context.TicketsDetalles
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
