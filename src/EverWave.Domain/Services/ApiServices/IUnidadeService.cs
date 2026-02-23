using EverWave.Domain.Dtos.HttpIn;

namespace EverWave.Domain.Services.ApiServices;

public interface IUnidadeService
{
    Task<object> CriaUnidadeAsync(UnidadeCriacaoDto unidadeDto, CancellationToken cancellationToken);
}