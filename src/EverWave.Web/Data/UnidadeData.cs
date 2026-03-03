using EverWave.Domain.Dtos.HttpIn;
using EverWave.Domain.Services;
using EverWave.Web.Values.Forms;
using EverWave.Web.Values.Table;

namespace EverWave.Web.Data;

public interface IUnidadeData
{
    Task CriaUnidadeAsync(CadastroUnidadeForm form);
    Task<List<UnidadeVisualizacaoTable>> ListaUnidadesAsync();
}

public class UnidadeData(IUnidadeService unidadeService) : IUnidadeData
{
    private readonly IUnidadeService _unidadeService = unidadeService;

    public async Task CriaUnidadeAsync(CadastroUnidadeForm form)
    {
        var unidadeCriacaoDto = new UnidadeCriacaoDto { Nome = form.Nome, };
        await _unidadeService.CriaAsync(unidadeCriacaoDto, CancellationToken.None);
    }

    public async Task<List<UnidadeVisualizacaoTable>> ListaUnidadesAsync()
    {
        var unidades = await _unidadeService.ObtemTodosAsync(CancellationToken.None);
        return unidades.Select(u => new UnidadeVisualizacaoTable
        {
            Nome = u.Nome, Fundacao = u.CreatedAt, UltimaAlteracao = u.UpdatedAt, Ativo = true
        }).ToList();
    }
}