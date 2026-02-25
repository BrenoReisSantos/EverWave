using EverWave.Data;
using EverWave.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace EverWave.Tests.DatabaseUtils;

public class UnidadeTableUtils(EverWaveContext context)
{
    private readonly EverWaveContext _context = context;

    public async Task<Unidade?> Get(Guid id)
    {
        var unidade = await _context.Unidades.FindAsync(id);
        _context.Entry(unidade).State = EntityState.Detached;
        return unidade;
    }

    public async Task<List<Unidade>> GetAll()
    {
        return await _context.Unidades.AsNoTracking().ToListAsync();
    }

    public async Task<Unidade?> Insert(Unidade unidade)
    {
        await _context.Unidades.AddAsync(unidade);
        await _context.SaveChangesAsync();
        return unidade;
    }
}