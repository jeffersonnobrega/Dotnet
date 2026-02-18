using Atendimento.Domain.Enums;

namespace Atendimento.Domain.DTOs;

public class TicketStatusUpdateDto
{
    public Guid Id { get; set; }
    public StatusAtendimento NovoStatus { get; set; }
}