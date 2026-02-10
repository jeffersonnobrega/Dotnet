using Atendimento.Domain.Interfaces;
using Atendimento.Domain.Entities;
using Atendimento.Domain.DTOs;

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

        public async Task<Ticket> CriarTicketAsync(TicketCreateDto ticketCreateDto)
        {
           var ticket = new Ticket
           {
               Id = Guid.NewGuid(),
               NumeroProtocolo = $"REQ-{DateTime.Now.Year}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}",
               Titulo = ticketCreateDto.Titulo,
               Descricao = ticketCreateDto.Descricao,
               DataCriacao = DateTime.Now,
               CpfCnpjCliente = ticketCreateDto.CpfCnpjCliente,
               Status = Enums.StatusAtendimento.Aberto,
           };

           return await _repository.AdicionarAsync(ticket);
        }

        public async Task<IEnumerable<Ticket>> ListarTicketsAsync()
        {
            return await _repository.ObterTodosAsync();
        }
    }
}