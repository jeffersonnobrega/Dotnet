using Atendimento.Domain.Entities;
using Atendimento.Domain.Interfaces;
using Atendimento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Atendimento.Infrastructure.Repository;

public class ClienteRepository : IClienteRepository
{
     private readonly AppDbContext _context;

     public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Cliente> AdicionarClienteAsync(Cliente cliente)
    {

        _context.Clientes.Add(cliente);        
        await _context.SaveChangesAsync();

        return cliente;
    }

    public Task AtualizarClienteAsync(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Task ExcluirClienteAsync(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public async Task<Cliente?> ObterClientePorCpfAsync(string cpfCnpj)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.CpfCnpjCliente == cpfCnpj);
    }

    public Task<Cliente?> ObterClientePorIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}