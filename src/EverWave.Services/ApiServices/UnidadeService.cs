using EverWave.Domain.Common;
using EverWave.Domain.Dtos.HttpIn;
using EverWave.Domain.Entities;
using EverWave.Domain.Repository;
using EverWave.Domain.Services.ApiServices;

namespace EverWave.Services.ApiServices;

public class UnidadeService(IUnidadeRepository repository, ITimeProvider timeProvider) : IUnidadeService
{
    private readonly IUnidadeRepository _repository = repository;
    private readonly ITimeProvider _timeProvider = timeProvider;

    public async Task<object> CriaUnidadeAsync(UnidadeCriacaoDto unidadeDto, CancellationToken cancellationToken)
    {
        var novaUnidade = new Unidade
        {
            Nome = unidadeDto.Nome,
            CreatedAt = _timeProvider.UtcNow
        };

        var unidadeCriada = await _repository.InsereUnidadeAsync(novaUnidade, cancellationToken);

        return null;
    }
}