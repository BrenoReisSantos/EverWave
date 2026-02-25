using EverWave.Domain.Entities;

namespace EverWave.Domain.Repository;

public interface IUnidadeRepository
{
    Task<Unidade?> InsereUnidadeAsync(Unidade unidade, CancellationToken cancellationToken);
    Task<Unidade?> ObtemAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Unidade>> ObtemTodosAsync(CancellationToken cancellationToken);
}