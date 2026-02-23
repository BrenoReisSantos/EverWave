using EverWave.Domain.Entities;

namespace EverWave.Domain.Repository;

public interface IUnidadeRepository
{
    Task<Unidade?> InsereUnidadeAsync(Unidade unidade, CancellationToken cancellationToken);
}