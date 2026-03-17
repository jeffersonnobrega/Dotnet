using Atendimento.Domain.DTOs;
using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Interfaces;

public interface IDepartamentoService
{
    Task<Response<Departamentos>>CriarDepartamentoAsync(DepartamentoCreateDto departamentosCreateDto);
    Task<Response<List<Departamentos>>>ListarDepartamentosAsync();
    Task<Response<Departamentos>>ListarDepartamentoPorIdAsync(int Id);
    Task<Response<DepartamentoResponseDto>>ListarDepartamentoPorCodEquipeAsync(string CodDepartamento);
}