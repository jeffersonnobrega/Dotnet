using Microsoft.AspNetCore.Mvc;
using Atendimento.Domain.Entities;
using Atendimento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Atendimento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TicketsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return Ok(tickets);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarTicketPorId(int id)
        {
            var ticketId = await _context.Tickets.FindAsync(id);
            
            if (ticketId == null)
                   return NotFound();

            return Ok(ticketId);  

        }         

        [HttpPost]
        public async Task<IActionResult> AdicionarTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);

            await _context.SaveChangesAsync();

            return CreatedAtAction
            (
                nameof(BuscarTicketPorId),
                new {id = ticket.Id},
                ticket
            );
        }
    }
}