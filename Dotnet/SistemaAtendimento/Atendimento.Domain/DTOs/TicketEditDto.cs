using Atendimento.Domain.Enums;

namespace Atendimento.Domain.DTOs;

    public class TicketEditDto
    {
       public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public StatusAtendimento Status { get; set; }
    }