using Microsoft.EntityFrameworkCore;
using Atendimento.Domain.Entities;
using Atendimento.Infrastructure.Context;
using Atendimento.Domain.Interfaces;

namespace Atendimento.Infrastructure.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> ObterTodosAsync()
        {
               return await _context.Tickets.ToListAsync(); 

        }

        public async Task<Ticket>ObterPorIdAsync(Guid idTicket)
        {
                
        return await _context.Tickets
            .FirstOrDefaultAsync(t => t.Id == idTicket);

        }

        public async Task<Ticket>AdicionarAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }


        
    }
}