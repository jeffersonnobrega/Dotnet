using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>>ListarTicketsAsync();

        Task<Ticket?>BuscarTicketPorIdAsync(Guid Id);

        Task<Ticket>CriarTicketAsync(Ticket ticket);


    }
}