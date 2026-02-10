using Microsoft.AspNetCore.Mvc;
using Atendimento.Domain.Entities;
using Atendimento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Atendimento.Domain.Interfaces;

namespace Atendimento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService ;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosTickets()
        {
            var tickets = await _ticketService.ListarTicketsAsync();
            return Ok(tickets);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarTicketPorId(Guid id)
        {
            var ticketId = await _ticketService.BuscarTicketPorIdAsync(id);
            
            if (ticketId == null)
                   return NotFound();

            return Ok(ticketId);  

        }         

        [HttpPost]
        public async Task<IActionResult> AdicionarTicket(Ticket ticket)
        {
           var novoTicket= await _ticketService.CriarTicketAsync(ticket);

            return Ok(novoTicket); 
        }
    }
}