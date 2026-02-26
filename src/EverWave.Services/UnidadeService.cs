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

    public async Task<Unidade?> CriaUnidadeAsync(UnidadeCriacaoDto unidadeDto, CancellationToken cancellationToken)
    {
        var novaUnidade = new Unidade
        {
            Nome = unidadeDto.Nome,
            CreatedAt = _timeProvider.UtcNow
        };

        return await _repository.InsereAsync(novaUnidade, cancellationToken);
    }
}