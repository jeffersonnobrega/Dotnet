using Atendimento.Domain.Entities;

namespace Atendimento.Domain.DTOs;

public class TicketClienteCreateDto
{
    public string CpfCnpjCliente { get; set;}
    public string Nome { get; set;}

    public int? DepartamentoId { get; set; }
    public Departamentos? Departamento { get; set; }
}