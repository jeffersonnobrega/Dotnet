    namespace Atendimento.Domain.DTOs;


    public class TicketCreateDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int ClienteId { get; set;}

        public int AgenteId { get; set;}
        public TicketClienteCreateDto Cliente { get; set; }
    }