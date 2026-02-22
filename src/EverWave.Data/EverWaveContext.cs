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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}