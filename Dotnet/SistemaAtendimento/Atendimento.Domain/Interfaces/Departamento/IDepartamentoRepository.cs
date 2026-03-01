using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Interfaces;

public interface IDepartamentoRepository
{
    Task<List<Departamentos?>> ObterDepartamentos ();
}    