namespace Atendimento.Domain.Entities;

public class Agente
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public string Matricula { get; set; }

    public int? DepartamentoId { get; set; }
    public Departamentos? Departamentos { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}