using EverWave.Data;
using EverWave.Domain.Entities;
using EverWave.Domain.Repository;

using Microsoft.EntityFrameworkCore;

namespace EverWave.Repository;

public class UnidadeRepository(EverWaveContext context) : IUnidadeRepository
{
    private readonly EverWaveContext _context = context;

    public async Task<Unidade?> InsereAsync(Unidade unidade, CancellationToken cancellationToken)
    {
        _context.Unidades.Add(unidade);
        await _context.SaveChangesAsync(cancellationToken);
        return unidade;
    }

    public async Task<Unidade?> ObtemAsync(Guid id, CancellationToken cancellationToken) =>
        await _context.Unidades.FindAsync([id], cancellationToken);

    public async Task<IEnumerable<Unidade>> ObtemTodosAsync(CancellationToken cancellationToken) =>
        await _context.Unidades.ToListAsync(cancellationToken);

    public async Task<Unidade> AtualizaAsync(Unidade unidade, CancellationToken cancellationToken)
    {
        _context.Update(unidade);
        await _context.SaveChangesAsync(cancellationToken);
        return unidade;
    }
}