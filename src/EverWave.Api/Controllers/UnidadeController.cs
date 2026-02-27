using EverWave.Domain.Dtos.HttpIn;
using EverWave.Domain.Services;

using Microsoft.AspNetCore.Mvc;

namespace EverWave.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnidadeController(IUnidadeService unidadeService) : ControllerBase
{
    private readonly IUnidadeService _unidadeService = unidadeService;

    [HttpPost]
    public async Task<IActionResult> CriaNovaUnidade(UnidadeCriacaoDto unidade, CancellationToken cancellationToken)
    {
        var unidadeCriada = await _unidadeService.CriaAsync(unidade, cancellationToken);
        return Ok(unidadeCriada);
    }
}