using System;
using System.Collections.Generic;
using System.Data;
using Atendimento.Domain.Enums;

namespace Atendimento.Domain.Entities{

    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public string CpfCnpjCliente { get; set;}
        public StatusAtendimento Status { get; set; }

    }
}    
