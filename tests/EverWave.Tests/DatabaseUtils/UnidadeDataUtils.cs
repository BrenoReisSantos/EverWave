using EverWave.Data;
using EverWave.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace EverWave.Tests.DatabaseUtils;

public class UnidadeDataUtils(EverWaveContext context)
{
    private readonly EverWaveContext _context = context;

    public async Task<Unidade?> GetAsync(Guid id)
    {
        var unidade = await _context.Unidades.AsNoTracking().SingleAsync(x => x.Id == id);
        return unidade;
    }

    public async Task<List<Unidade>> GetAllAsync()
    {
        return await _context.Unidades.AsNoTracking().ToListAsync();
    }

    public async Task InsertAsync(Unidade unidade)
    {
        _context.Unidades.Add(unidade);
        await _context.SaveChangesAsync();
        _context.Entry(unidade).State = EntityState.Detached;
    }

    public async Task InsertManyAsync(IEnumerable<Unidade> unidades)
    {
        _context.Unidades.AddRange(unidades);
        await _context.SaveChangesAsync();
        
        foreach (var unidade in unidades)
            _context.Entry(unidade).State = EntityState.Detached;
    }
}