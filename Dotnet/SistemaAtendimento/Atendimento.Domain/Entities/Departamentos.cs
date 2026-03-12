using System.ComponentModel.DataAnnotations;

namespace Atendimento.Domain.Entities;

public class Departamentos
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O Alias é obrigatório.")]
    [MinLength(3, ErrorMessage = "O Alias deve ter no mínimo 3 caracteres.")]
    [StringLength(100)]
    public string Alias { get; set; } = string.Empty;
    public string? CodDepartamento { get; set; } = string.Empty;
    
}