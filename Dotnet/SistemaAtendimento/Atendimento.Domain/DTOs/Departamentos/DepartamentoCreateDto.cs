using System.ComponentModel.DataAnnotations;

namespace Atendimento.Domain.DTOs;

public class DepartamentoCreateDto
{
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O apelido é obrigatório.")]
    [MinLength(3, ErrorMessage = "O apelido deve ter pelo menos 3 letras.")]
    [MaxLength(100)]
    public string Alias { get; set; } = string.Empty;
}