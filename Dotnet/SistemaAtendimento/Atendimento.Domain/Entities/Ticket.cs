using System;
using System.Collections.Generic;
using System.Data;
using Atendimento.Domain.Enums;

namespace Atendimento.Domain.Entities{

    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? NumeroProtocolo { get; set; } = string.Empty;
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
        public DateTime? DataFechamento { get; set; } 
        public int ClienteId { get; set; }
        public Cliente Cliente{ get; set; }
        public int AgenteId { get; set; }
        public Agente Agente{ get; set; }
        public StatusAtendimento Status { get; set; }

    }
}    
