using EverWave.Domain.Common;
using EverWave.Domain.Dtos.HttpIn;
using EverWave.Domain.Entities;
using EverWave.Domain.Repository;
using EverWave.Domain.Services;

namespace EverWave.Services;

public class UnidadeService(IUnidadeRepository repository, ITimeProvider timeProvider) : IUnidadeService
{
    private readonly IUnidadeRepository _repository = repository;
    private readonly ITimeProvider _timeProvider = timeProvider;

    public async Task<Unidade?> CriaAsync(UnidadeCriacaoDto unidadeDto, CancellationToken cancellationToken)
    {
        var novaUnidade = new Unidade { Nome = unidadeDto.Nome, CreatedAt = _timeProvider.UtcNow };

        return await _repository.InsereAsync(novaUnidade, cancellationToken);
    }

    public async Task<IEnumerable<Unidade>> ObtemTodosAsync(CancellationToken cancellationToken) =>
        await _repository.ObtemTodosAsync(cancellationToken);

    public async Task<Unidade?> ObtemAsync(Guid id, CancellationToken cancellationToken) =>
        await _repository.ObtemAsync(id, cancellationToken);

    public async Task<Unidade> AtualizaAsync(Unidade unidade, CancellationToken cancellationToken)
    {
        unidade.UpdatedAt = _timeProvider.UtcNow;
        return await _repository.AtualizaAsync(unidade, cancellationToken);
    }
}