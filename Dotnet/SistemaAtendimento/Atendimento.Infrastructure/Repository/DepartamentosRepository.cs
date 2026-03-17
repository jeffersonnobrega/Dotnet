using Atendimento.Domain.Entities;
using Atendimento.Domain.Interfaces;
using Atendimento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Atendimento.Infrastructure.Repository;

public class DepartamentosRepository : IDepartamentoRepository
{
    private readonly AppDbContext _context;

    public DepartamentosRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Departamentos> AdicionarDepartamentoAsync(Departamentos departamentos)
    {
        _context.Departamentos.Add(departamentos);
        await _context.SaveChangesAsync();
        return departamentos;
    }

    public async Task<Departamentos?> ObterDepartamentoPorCodEquipeAsync(string codDepartamento)
    {
        return await _context.Departamentos.FirstOrDefaultAsync(c => c.CodDepartamento == codDepartamento);
    }

    public async Task<Departamentos?> ObterDepartamentoPorIdAsync(int idDepartamento)
    {
        return await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == idDepartamento);
    }

    public async Task<List<Departamentos>> ObterDepartamentosAsync()
    {
        return await _context.Departamentos.ToListAsync();
    }

    public async Task<int> ObterQuantidadeDepartamentosAsync()
    {
        return await _context.Departamentos.CountAsync();
    }
}