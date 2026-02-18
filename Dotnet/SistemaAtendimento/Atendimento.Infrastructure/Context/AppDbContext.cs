using Microsoft.EntityFrameworkCore;
using Atendimento.Domain.Entities; 

namespace Atendimento.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Agente> Agentes { get; set; }
    public DbSet<Departamentos> Departamentos { get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Ticket>(entity => {
            entity.HasKey(t => t.Id);
            entity.HasIndex(t => t.NumeroProtocolo).IsUnique();
            entity.Property(t => t.Titulo).IsRequired().HasMaxLength(100);
            entity.Property(t => t.Status).HasConversion<string>();
            entity.Property(t => t.DataCriacao).HasDefaultValueSql("GETDATE()");
            entity.Property(t => t.DataAlteracao).HasDefaultValueSql("GETDATE()");
            entity.Property(t => t.DataFechamento).IsRequired(false);   

            entity.HasOne(t => t.Cliente)
              .WithMany() // Se o Cliente não tiver uma lista de Tickets, deixe vazio
              .HasForeignKey(t => t.ClienteId)
              .OnDelete(DeleteBehavior.Restrict); // Evita deletar cliente se tiver ticket

        // Relacionamento Ticket -> Agente
        entity.HasOne(a => a.Agente)
              .WithMany(a => a.Tickets)
              .HasForeignKey(t => t.AgenteId);
              
        });

        modelBuilder.Entity<Agente>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd();

            entity.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(a => a.Matricula)
                .IsRequired()
                .HasMaxLength(20);

            // CONFIGURAÇÃO DO RELACIONAMENTO:
            // O Agente pertence a UM Departamento
            entity.HasOne(a => a.Departamentos)
                .WithMany() 
                .HasForeignKey("DepartamentoId"); 
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(c=> c.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.CpfCnpjCliente).IsRequired().HasMaxLength(14);
            entity.Property(c => c.Nome).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<Departamentos>(entity =>
        {
            entity.Property(p=> p.Id).ValueGeneratedOnAdd();
            entity.Property(p=> p.Nome).IsRequired().HasMaxLength(150);
            entity.HasIndex(p=> p.CodDepartamento).IsUnique();
        });
    }
}