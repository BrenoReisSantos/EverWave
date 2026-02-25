using EverWave.Domain.Repository;
using EverWave.Repository;
using EverWave.Tests.Common;
using EverWave.Tests.Common.Builders.Entities;
using EverWave.Tests.DatabaseUtils;

using Shouldly;

namespace EverWave.Tests.Specs.Repository;

public class UnidadeRepositoryTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _databaseFixture;
    private readonly IUnidadeRepository _sut;
    private readonly UnidadeDataUtils _unidadeDataUtils;

    public UnidadeRepositoryTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
        _sut = new UnidadeRepository(_databaseFixture.Context);
        _unidadeDataUtils = new UnidadeDataUtils(_databaseFixture.Context);
    }

    [Fact]
    public async Task InsereUnidadeAsync_InsereNovaUnidadeNoBanco()
    {
        var unidade = new UnidadeBuilder().ComoNovaEntidade().Generate();

        var novaUnidade = await _sut.InsereUnidadeAsync(unidade, CancellationToken.None);

        var unidadeDoBd = await _unidadeDataUtils.Get(novaUnidade.Id);

        novaUnidade.Nome.ShouldBe(unidadeDoBd?.Nome);
        novaUnidade.CreatedAt.ShouldBe(unidadeDoBd!.CreatedAt);
        novaUnidade.UpdatedAt.ShouldBe(unidadeDoBd?.UpdatedAt);
        novaUnidade.Id.ShouldBe(unidadeDoBd!.Id);
    }

    [Fact]
    public async Task Obtem_RetornaUnidadeComIdEspecifico()
    {
        var unidade = new UnidadeBuilder().ComoNovaEntidade().Generate();
        await _unidadeDataUtils.Insert(unidade);

        var result = await _sut.ObtemAsync(unidade.Id, CancellationToken.None);

        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task ObtemTodos_RetornaTodasAsUnidadesDoBanco()
    {
        var quantidadeUnidades = 3;
        var unidades = new UnidadeBuilder().ComoNovaEntidade().Generate(quantidadeUnidades);
        await _unidadeDataUtils.Insert(unidades);

        var result = await _sut.ObtemTodosAsync(CancellationToken.None);

        result.Count().ShouldBe(quantidadeUnidades);
    }
}