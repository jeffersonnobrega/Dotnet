using Atendimento.Domain.DTOs;
using Atendimento.Domain.Entities;
using Atendimento.Domain.Enums;

namespace Atendimento.Domain.Interfaces
{
    public interface ITicketService
    {
        Task<Response<List<Ticket>>> ListarTicketsAsync();

        Task<Response<List<Ticket>>> ListarTicketsPorStatusAsync(StatusAtendimento status);

        Task<Response<Ticket>>ListarTicketPorIdAsync(Guid Id);

        Task<Response<Ticket>>CriarTicketAsync(TicketCreateDto ticketCreateDto);

        Task<Response<Ticket>>EditarTicketAsync(TicketEditDto ticketEditDto);

        Task<Response<Ticket>>EditarStatusTicketAsync(TicketStatusUpdateDto ticketStatusUpdateDto);


    }
}