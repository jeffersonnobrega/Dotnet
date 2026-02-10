using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Interfaces
{
    public interface ITicketRepository
    {
        // O termo "Listar" é de negócio, o Repository costuma usar "Obter" ou "Get"
        Task<IEnumerable<Ticket>> ObterTodosAsync();

        Task<Ticket?> ObterPorIdAsync(Guid id);

        // O termo "Criar" é de negócio, o Repository usa "Adicionar" ou "Add"
        Task<Ticket> AdicionarAsync(Ticket ticket);
    }
}