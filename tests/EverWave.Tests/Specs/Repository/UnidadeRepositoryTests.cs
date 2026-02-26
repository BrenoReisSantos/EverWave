using Bogus;

using EverWave.Domain.Repository;
using EverWave.Repository;
using EverWave.Tests.Common;
using EverWave.Tests.Common.Builders.Entities;
using EverWave.Tests.DatabaseUtils;

using Shouldly;

namespace EverWave.Tests.Specs.Repository;

public class UnidadeRepositoryTests : BasicDatabaseFixture, IClassFixture<BasicDatabaseFixture>
{
    private readonly IUnidadeRepository _sut;
    private readonly UnidadeDataUtils _unidadeDataUtils;

    public UnidadeRepositoryTests()
    {
        _sut = new UnidadeRepository(Context);
        _unidadeDataUtils = new UnidadeDataUtils(Context);
    }

    [Fact]
    public async Task InsereAsync_InsereNovaUnidadeNoBanco()
    {
        var unidade = new UnidadeBuilder().ComoNovaEntidade().Generate();

        var novaUnidade = await _sut.InsereAsync(unidade, CancellationToken.None);

        var unidadeDoBd = await _unidadeDataUtils.GetAsync(novaUnidade.Id);

        novaUnidade.Nome.ShouldBe(unidadeDoBd?.Nome);
        novaUnidade.CreatedAt.ShouldBe(unidadeDoBd!.CreatedAt, TimeSpan.FromMilliseconds(500));
        novaUnidade.UpdatedAt?.ShouldBe(unidadeDoBd.UpdatedAt!.Value, TimeSpan.FromMilliseconds(500));
        novaUnidade.Id.ShouldBe(unidadeDoBd.Id);
    }

    [Fact]
    public async Task ObtemAsync_RetornaUnidadeComIdEspecifico()
    {
        var unidade = new UnidadeBuilder().ComoNovaEntidade().Generate();
        await _unidadeDataUtils.InsertAsync(unidade);

        var result = await _sut.ObtemAsync(unidade.Id, CancellationToken.None);

        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task ObtemTodosAsync_RetornaTodasAsUnidadesDoBanco()
    {
        var quantidadeUnidades = 3;
        var unidades = new UnidadeBuilder().ComoNovaEntidade().Generate(quantidadeUnidades);
        await _unidadeDataUtils.InsertManyAsync(unidades);

        var result = await _sut.ObtemTodosAsync(CancellationToken.None);

        result.Count().ShouldBe(quantidadeUnidades);
    }

    [Fact]
    public async Task AtualizaAsync_AtualizaEntidadeNoBancoDeDados()
    {
        var unidade = new UnidadeBuilder().ComoNovaEntidade().Generate();
        await _unidadeDataUtils.InsertAsync(unidade);

        var nomeEsperado = Faker.Company.CompanyName(0);
        var createdAtEsperado = Faker.Date.Past().ToUniversalTime();
        var updatedAtEsperado = Faker.Date.Recent().ToUniversalTime();
        var unidadeAtualizando = new UnidadeBuilder().ComId(unidade.Id).ComNome(nomeEsperado)
            .ComUpdatedAt(updatedAtEsperado)
            .ComCreatedAt(createdAtEsperado).Generate();

        await _sut.AtualizaAsync(unidadeAtualizando, CancellationToken.None);

        var result = await _unidadeDataUtils.GetAsync(unidade.Id);

        result.Nome.ShouldBe(nomeEsperado);
        result.CreatedAt.ShouldBe(createdAtEsperado, TimeSpan.FromMilliseconds(500));
        result.UpdatedAt?.ShouldBe(updatedAtEsperado, TimeSpan.FromMilliseconds(500));
    }
}