using Microsoft.AspNetCore.Mvc;
using Atendimento.Domain.Interfaces;
using Atendimento.Domain.DTOs;
using Atendimento.Domain.Enums;

namespace Atendimento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("BuscarTodosTickets")]
        public async Task<IActionResult> BuscarTodosTickets()
        {
            var resposta = await _ticketService.ListarTicketsAsync();
            return resposta.Status ? Ok(resposta) : BadRequest(resposta);
        }

        [HttpGet("BuscarPor/{id}")]
        public async Task<IActionResult> BuscarTicketPorId(Guid id)
        {
            var resposta = await _ticketService.ListarTicketPorIdAsync(id);
            if (resposta == null || !resposta.Status) return NotFound(resposta);
            return Ok(resposta);
        }

        [HttpGet("BuscarPorStatus")]
        public async Task<IActionResult> BuscarTicketPorStaus(StatusAtendimento status)
        {
            var resposta = await _ticketService.ListarTicketsPorStatusAsync(status);
            return resposta.Status ? Ok(resposta) : BadRequest(resposta);
        }

        [HttpPost("AdicionarTicket")]
        public async Task<IActionResult> AdicionarTicket(TicketCreateDto ticketCreateDto)
        {
            var resposta = await _ticketService.CriarTicketAsync(ticketCreateDto);
            if (!resposta.Status) return BadRequest(resposta);

            return CreatedAtAction(nameof(BuscarTicketPorId), new { id = resposta.Dados!.Id }, resposta);
        }

        [HttpPut("EditarTicket")]
        public async Task<IActionResult> EditarTicket(TicketEditDto ticketEditDto)
        {
            var resposta = await _ticketService.EditarTicketAsync(ticketEditDto);
            return resposta.Status ? Ok(resposta) : BadRequest(resposta);
        }

        [HttpPut("EditarStatusTicket")]
        public async Task<IActionResult> EditarStatusTicket(TicketStatusUpdateDto ticketStatusUpdateDto)
        {
            var resposta = await _ticketService.EditarStatusTicketAsync(ticketStatusUpdateDto);
            return resposta.Status ? Ok(resposta) : BadRequest(resposta);
        }
    }
}