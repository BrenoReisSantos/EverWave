using EverWave.Data;
using EverWave.Domain.Entities;
using EverWave.Domain.Repository;

using Microsoft.EntityFrameworkCore;

namespace EverWave.Repository;

public class UnidadeRepository(EverWaveContext context) : IUnidadeRepository
{
    private readonly EverWaveContext _context = context;

    public async Task<Unidade?> InsereUnidadeAsync(Unidade unidade, CancellationToken cancellationToken)
    {
        _context.Unidades.Add(unidade);
        await _context.SaveChangesAsync(cancellationToken);
        return unidade;
    }
    
    public async Task<Unidade?> Obtem(Guid id) => await _context.Unidades.FindAsync(id);
    
    public async Task<IEnumerable<Unidade>> ObtemTodos() => await _context.Unidades.ToListAsync();
}