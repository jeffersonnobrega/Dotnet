using Atendimento.Domain.Interfaces;
using Atendimento.Domain.Entities;
using Atendimento.Domain.DTOs;
using Atendimento.Domain.Enums;

namespace Atendimento.Domain.Services
{
    public class TicketService: ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly IClienteRepository _clienteRepository;

        public TicketService (ITicketRepository ticketRepository, IClienteRepository clienteRepository)
        {
            _repository = ticketRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<Response<Ticket>> ListarTicketPorIdAsync(Guid Id)
        {
            Response<Ticket> resposta = new Response<Ticket>();

            try
            {
                var ticket = await _repository.ObterPorIdAsync(Id);
                
                if (ticket == null)
                {
                    resposta.Mensagem = "Ticket não localizado.";
                    resposta.Status = false;

                    return resposta;
                }

                resposta.Mensagem = "Ticket localizado";
                resposta.Status = true;
                resposta.Dados = ticket;

                return resposta;
            }
            catch (Exception ex)
            {
                
                resposta.Mensagem = $"Erro ao buscar o Id: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<Ticket>> CriarTicketAsync(TicketCreateDto ticketCreateDto)

        {
            Response<Ticket> resposta = new Response<Ticket>();

            try
            {
                var clienteExistente = await _clienteRepository.ObterClientePorCpfAsync(ticketCreateDto.Cliente.CpfCnpjCliente);

                if (clienteExistente == null)
                {
                    clienteExistente = new Cliente
                    {
                        Nome = ticketCreateDto.Cliente.Nome,
                        CpfCnpjCliente  = ticketCreateDto.Cliente.CpfCnpjCliente,
                        DepartamentoId  = ticketCreateDto.Cliente.DepartamentoId,
                    }; 

                    await _clienteRepository.AdicionarClienteAsync(clienteExistente); 
                } 
                
                var ticket = new Ticket
                    {
                    Id = Guid.NewGuid(),
                    NumeroProtocolo = $"REQ-{DateTime.Now.Year}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}",
                    ClienteId = clienteExistente.Id,
                    Titulo = ticketCreateDto.Titulo,
                    Descricao = ticketCreateDto.Descricao,
                    DataCriacao = DateTime.Now,
                    Status = Enums.StatusAtendimento.Aberto,
                    };       


                await _repository.AdicionarAsync(ticket);

                resposta.Mensagem = "Ticket criado com sucesso.";
                resposta.Dados = ticket;
                return resposta;
                
            }
            catch (Exception ex)
            {
                
                resposta.Mensagem = $"Erro ao criar: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }
            

          
        }

        public async Task<Response<Ticket>> EditarStatusTicketAsync(TicketStatusUpdateDto ticketStatusUpdateDto)
        {
            Response<Ticket> resposta = new Response<Ticket>();

            try
            {
                var ticketLocalizado = await _repository.ObterPorIdAsync(ticketStatusUpdateDto.Id);

                    if (ticketLocalizado == null)
                    {
                        resposta.Mensagem = "Ticket não localizado";
                        resposta.Status = false;
                        return resposta;
                    }

                    if (ticketLocalizado.Status == StatusAtendimento.Concluido)
                    {
                        resposta.Mensagem = "Não é possível alterar o status de ticket já concluído";
                        resposta.Status = false;
                        return resposta;
                    }

                    if (ticketLocalizado.Status == ticketStatusUpdateDto.NovoStatus)
                    {
                        resposta.Mensagem = "O ticket já possui este status.";
                        return resposta; 
                    }
                
                ticketLocalizado.Status = ticketStatusUpdateDto.NovoStatus;

                resposta.Dados = await _repository.EditarStatusAsync(ticketLocalizado);
                resposta.Mensagem = "Status do Ticket alterado com sucesso";
                resposta.Status = true;

        return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro ao editar: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }         

            
        }

        public async Task<Response<Ticket>> EditarTicketAsync(TicketEditDto ticketEditDto)
        {
            Response<Ticket> resposta = new Response<Ticket>();

            try
            {
                var ticketLocalizado = await _repository.ObterPorIdAsync(ticketEditDto.Id);

                    if (ticketLocalizado == null)
                    {
                        resposta.Mensagem = "Ticket não localizado";
                        resposta.Status = false;
                        return resposta;
                    }

                    if (ticketLocalizado.Status == StatusAtendimento.Concluido)
                    {
                        resposta.Mensagem = "Não é possível alterar um ticket já concluído";
                        resposta.Status = false;
                        return resposta;
                    }

                ticketLocalizado.Titulo = ticketEditDto.Titulo;
                ticketLocalizado.Descricao = ticketEditDto.Descricao;
                ticketLocalizado.Status = ticketEditDto.Status;

                resposta.Dados = await _repository.EditarTicketAsync(ticketLocalizado);
                resposta.Mensagem = "Ticket alterado com sucesso";
                resposta.Status = true;

        return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro ao editar: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }         

       }

        public async Task<Response<List<Ticket>>> ListarTicketsAsync()
        {
            Response<List<Ticket>> resposta = new Response<List<Ticket>>();

            try
            {
                var tickets = await _repository.ObterTodosAsync();

                if(tickets == null)
                {
                    resposta.Mensagem = "Tickets não localizado";
                    resposta.Status = false;
                    return resposta;
                }
                
                resposta.Mensagem = "Tickets localizados";
                resposta.Dados = tickets;
                resposta.Status = true;
                
                return resposta;                                                
            }
            catch (Exception ex)
            {                
                resposta.Mensagem = $"Erro ao buscar Tickets: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Response<List<Ticket>>> ListarTicketsPorStatusAsync(StatusAtendimento status)
        {
              Response<List<Ticket>> resposta = new Response<List<Ticket>>();

           try
           {
                var statusTicket = await _repository.ObterPorStatusAsync(status);

                resposta.Mensagem = statusTicket.Any() ? "Tickets localizados" : "Nenhum ticket localizado";
                resposta.Dados = statusTicket;
                resposta.Status = true;

                return resposta;
           }
           catch (Exception ex)
           {
                resposta.Mensagem = $"Erro ao buscar Status dos tickets: {ex.Message}";
                resposta.Status = false;
                return resposta;
           }
        } 
        
    }
}