using System.ComponentModel.DataAnnotations;

namespace Atendimento.Domain.DTOs;

public class DepartamentoResponseDto
{
    
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string CodDepartamento { get; set; } = string.Empty;
        public string ExibicaoCompleta => $"{CodDepartamento} - {Nome}";
    

}