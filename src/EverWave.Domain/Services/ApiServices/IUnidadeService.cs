using EverWave.Domain.Dtos.HttpIn;
using EverWave.Domain.Entities;

namespace EverWave.Domain.Services.ApiServices;

public interface IUnidadeService
{
    Task<Unidade> CriaUnidadeAsync(UnidadeCriacaoDto unidadeDto, CancellationToken cancellationToken);
}