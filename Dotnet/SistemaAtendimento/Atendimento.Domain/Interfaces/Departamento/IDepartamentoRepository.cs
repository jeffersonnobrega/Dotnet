using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Interfaces;

public interface IDepartamentoRepository
{
    
    Task<Departamentos> AdicionarDepartamentoAsync(Departamentos departamentos);
    Task<List<Departamentos>>ObterDepartamentos();
    Task<Departamentos?> ObterDepartamentoPorIdAsync(int id);
    Task<Departamentos?> ObterDepartamentoPorCodEquipeAsync(string CodDepartamento);
    Task<int> ObterQuantidadeDepartamentosAsync();
    
}    