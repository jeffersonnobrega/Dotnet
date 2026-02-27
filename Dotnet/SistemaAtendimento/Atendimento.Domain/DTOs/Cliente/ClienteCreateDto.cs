namespace Atendimento.Domain.DTOs;

public class ClienteCreateDto
{
    public string CpfCnpjCliente { get; set;}
    public string Nome { get; set;}

    public int? DepartamentoId { get; set; }

}