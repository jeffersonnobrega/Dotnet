using Atendimento.Domain.Entities;

namespace Atendimento.Domain.DTOs;

public class ClienteResponseDto
{ 
    public int Id { get; set; }
    public string CpfCnpjCliente { get; set; }
    public string Nome { get; set; }
    public int? DepartamentoId { get; set; }   
    public string? NomeDepartamento { get; set; }
}