using Atendimento.Domain.Interfaces;
using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Services
{
    public class TicketService: ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService (ITicketRepository ticketRepository)
        {
            _repository = ticketRepository;
        }

        public async Task<Ticket?> BuscarTicketPorIdAsync(Guid Id)
        {
            return await _repository.ObterPorIdAsync(Id);
        }

        public async Task<Ticket> CriarTicketAsync(Ticket ticket)
        {
            ticket.Id = Guid.NewGuid();
            
            ticket.NumeroProtocolo = $"REQ-{DateTime.Now.Year}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";
            ticket.DataCriacao = DateTime.Now;
            ticket.Status = Enums.StatusAtendimento.Aberto;
            return await _repository.AdicionarAsync(ticket);
        }

        public async Task<IEnumerable<Ticket>> ListarTicketsAsync()
        {
            return await _repository.ObterTodosAsync();
        }
    }
}