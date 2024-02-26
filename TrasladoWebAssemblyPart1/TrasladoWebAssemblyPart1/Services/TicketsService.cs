using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrasladoWebAssemblyPart1.DAL;
using TrasladoWebAssemblyPart1.Models;

namespace TrasladoWebAssemblyPart1.Services
{
    public class TicketsService
    {
        private readonly Context _context;

        public TicketsService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int TicketId)
        {
            return await _context.Tickets.AnyAsync(t => t.TicketId == TicketId);
        }

        public async Task<bool> Agregar(Tickets Ticket)
        {
            _context.Tickets.Add(Ticket);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Tickets Ticket)
        {
            _context.Update(Ticket);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Tickets Ticket)
        {
            if (!await Verificar(Ticket.TicketId))
                return await Agregar(Ticket);
            else
                return await Modificar(Ticket);
        }

        public async Task<bool> Eliminar(Tickets Ticket)
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

        public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
        {
            return await _context.Tickets
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
