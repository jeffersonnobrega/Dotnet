    namespace Atendimento.Domain.DTOs;

    public class TicketCreateDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string CpfCnpjCliente { get; set; } = string.Empty;
    }