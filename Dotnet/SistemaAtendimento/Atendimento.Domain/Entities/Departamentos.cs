namespace Atendimento.Domain.Entities;

public class Departamentos
{
    public int Id { get; set; }

    public string Nome { get; set; }
    public string? CodDepartamento { get; set; } = string.Empty;
    
}