using EverWave.Data.Config;
using EverWave.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EverWave.Data;

public class EverWaveContext : DbContext
{
    public DbSet<Membro> Membros { get; init; }
    public DbSet<Contato> Contatos { get; init; }
    public DbSet<Unidade> Unidades { get; init; }
    public DbSet<Ministerio> Ministerios { get; init; }
    public DbSet<Cargo> Cargos { get; init; }
    public DbSet<MinisterioLocal> MinisteriosLocais { get; init; }
    public DbSet<ParticipacaoMinisterioLocal> ParticipacoesMinisteriosLocais { get; init; }

    public EverWaveContext(DbContextOptions<EverWaveContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MembroEntityConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}