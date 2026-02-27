using EverWave.Domain.Dtos.HttpIn;
using EverWave.Domain.Entities;

namespace EverWave.Domain.Services;

public interface IUnidadeService
{
    Task<Unidade?> CriaAsync(UnidadeCriacaoDto unidadeDto, CancellationToken cancellationToken);
}