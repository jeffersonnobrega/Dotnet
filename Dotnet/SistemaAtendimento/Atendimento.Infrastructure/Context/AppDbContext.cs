using Microsoft.EntityFrameworkCore;
using Atendimento.Domain.Entities; // <-- VERIFIQUE SE ESTÁ EXATAMENTE ASSIM

namespace Atendimento.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Ticket>(entity => {
            entity.Property(t => t.CpfCnpjCliente).IsRequired().HasMaxLength(20);
            entity.Property(t => t.Titulo).IsRequired().HasMaxLength(100);
            entity.Property(t => t.Status).HasConversion<string>();
            entity.Property(t => t.DataCriacao).HasDefaultValueSql("GETDATE()");
        });
    }
}