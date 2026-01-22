using Microsoft.EntityFrameworkCore;
using Atendimento.Domain.Entities; // <-- VERIFIQUE SE ESTÁ EXATAMENTE ASSIM

namespace Atendimento.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; } // O erro está aqui!

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Ticket>(entity => {
            entity.Property(t => t.CpfCnpjCliente).IsRequired().HasMaxLength(20);
            entity.Property(t => t.Titulo).IsRequired().HasMaxLength(100);
        });
    }
}