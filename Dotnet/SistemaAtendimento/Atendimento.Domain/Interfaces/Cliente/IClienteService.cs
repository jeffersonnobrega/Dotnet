using Atendimento.Domain.DTOs;
using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Interfaces;

public interface IClienteService
{
    Task<Response<ClienteResponseDto>> CriarClienteAsync(ClienteCreateDto clienteCreateDto);
    Task<Response<ClienteResponseDto>> EditarClienteAsync(ClienteCreateDto clienteCreateDto);
    Task<Response<List<ClienteResponseDto>>> ListarClientesAsync();    
    Task<Response<ClienteResponseDto>> DesativarClienteAsync(int id);
    Task<Response<ClienteResponseDto>> ExcluirClienteAsync(int id);

}