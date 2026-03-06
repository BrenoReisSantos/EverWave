using EverWave.Domain.Dtos.HttpIn;
using EverWave.Domain.Entities;
using EverWave.Domain.Services;
using EverWave.Web.Values.Forms;
using EverWave.Web.Values.Table;

namespace EverWave.Web.Data;

public interface IUnidadeData
{
    Task CriaUnidadeAsync(CadastroUnidadeForm form);
    Task<List<UnidadeVisualizacaoTable>> ListaUnidadesAsync();
    Task AtualizaUnidadeAsync(AtualizacaoUnidadeForm form);
    Task<Unidade?> ObtemAsync(Guid id);
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
            Nome = u.Nome,
            Fundacao = u.CreatedAt,
            UltimaAlteracao = u.UpdatedAt,
            Ativo = true,
            Id = u.Id
        }).ToList();
    }

    public async Task<Unidade?> ObtemAsync(Guid id) => await _unidadeService.ObtemAsync(id, CancellationToken.None);

    public async Task AtualizaUnidadeAsync(AtualizacaoUnidadeForm form)
    {
        var unidadeAtuailzacaoDto = new Unidade { Nome = form.Nome, };
        await _unidadeService.AtualizaAsync(unidadeAtuailzacaoDto, CancellationToken.None);
    }
}