using Atendimento.Domain.Entities;
namespace Atendimento.Domain.Interfaces;

public interface IClienteRepository
{Task<Cliente?> ObterClientePorCpfAsync(string cpfCnpj);
    Task<Cliente?> ObterClientePorIdAsync(int id); 
    Task<Cliente> AdicionarClienteAsync(Cliente cliente);
    Task<Cliente> EditarClienteAsync(Cliente cliente);
    Task AtualizarClienteAsync(Cliente cliente); 
    Task ExcluirClienteAsync(Cliente cliente);

}