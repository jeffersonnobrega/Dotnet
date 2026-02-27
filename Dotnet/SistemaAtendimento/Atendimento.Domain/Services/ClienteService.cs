using Atendimento.Domain.DTOs;
using Atendimento.Domain.Entities;
using Atendimento.Domain.Interfaces;

namespace Atendimento.Domain.Services;

public class ClienteService : IClienteService
{
    public Task<Response<ClienteResponseDto>> CriarClienteAsync(ClienteCreateDto clienteCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<ClienteResponseDto>> DesativarClienteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<ClienteResponseDto>> ExcluirClienteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<ClienteResponseDto>>> ListarClientesAsync()
    {
        throw new NotImplementedException();
    }
}