using EverWave.Domain.Dtos.HttpIn;
using EverWave.Domain.Entities;

namespace EverWave.Domain.Services;

public interface IUnidadeService
{
    Task<Unidade?> CriaAsync(UnidadeCriacaoDto unidadeDto, CancellationToken cancellationToken);
    Task<IEnumerable<Unidade>> ObtemTodosAsync(CancellationToken cancellationToken);
    Task<Unidade?> ObtemAsync(Guid id, CancellationToken cancellationToken);
    Task<Unidade> AtualizaAsync(Unidade unidade, CancellationToken cancellationToken);
}