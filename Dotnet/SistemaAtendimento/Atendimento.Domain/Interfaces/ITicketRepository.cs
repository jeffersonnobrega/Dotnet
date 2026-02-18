using Atendimento.Domain.Entities;
using Atendimento.Domain.Enums;

namespace Atendimento.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> ObterTodosAsync();

        Task<Ticket?> ObterPorIdAsync(Guid id);

        Task<List<Ticket>> ObterPorStatusAsync(StatusAtendimento status);

       Task<Ticket> AdicionarAsync(Ticket ticket);

        Task<Ticket> EditarTicketAsync(Ticket ticket);

        Task<Ticket> EditarStatusAsync(Ticket ticket);
    }
}