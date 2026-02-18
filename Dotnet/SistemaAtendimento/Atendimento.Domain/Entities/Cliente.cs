
namespace Atendimento.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string CpfCnpjCliente { get; set;}
    public string Nome { get; set;}

    public int? DepartamentoId { get; set; }
    public Departamentos? Departamento { get; set; }
}