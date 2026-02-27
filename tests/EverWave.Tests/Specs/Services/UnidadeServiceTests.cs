using EverWave.Domain.Common;
using EverWave.Domain.Entities;
using EverWave.Domain.Repository;
using EverWave.Domain.Services;
using EverWave.Services;
using EverWave.Tests.Common;
using EverWave.Tests.Common.Builders.Dtos.HttpIn;
using EverWave.Tests.Common.Builders.Entities;

using NSubstitute;

using Shouldly;

namespace EverWave.Tests.Specs.Services;

public class UnidadeServiceTests : BaseUnitTest
{
    private readonly IUnidadeService _sut;
    private readonly IUnidadeRepository _unidadeRepositoryMock;
    private readonly ITimeProvider _timeProviderMock;

    public UnidadeServiceTests()
    {
        _unidadeRepositoryMock = Substitute.For<IUnidadeRepository>();
        _timeProviderMock = Substitute.For<ITimeProvider>();
        _sut = new UnidadeService(_unidadeRepositoryMock, _timeProviderMock);
    }

    [Fact]
    public async Task CriaUnidadeAsync_RetornaResultadoDoRepositorio()
    {
        var unidadeDto = new UnidadeCriacaoDtoBuilder().Generate();
        var unidadeEsperada = new UnidadeBuilder().Generate();

        var idEsperado = unidadeEsperada.Id;
        var nomeEsperado = unidadeEsperada.Nome;
        var createdAtEsperado = unidadeEsperada.CreatedAt;
        var updatedAtEsperado = unidadeEsperada.UpdatedAt;

        _unidadeRepositoryMock
            .InsereAsync(Arg.Any<Unidade>(), Arg.Any<CancellationToken>())
            .Returns(unidadeEsperada);

        var resultado = await _sut.CriaAsync(unidadeDto, CancellationToken.None);

        resultado.ShouldNotBeNull();
        resultado.Id.ShouldBe(idEsperado);
        resultado.Nome.ShouldBe(nomeEsperado);
        resultado.CreatedAt.ShouldBe(createdAtEsperado);
        resultado.UpdatedAt.ShouldBe(updatedAtEsperado);
    }

    [Fact]
    public async Task CriaUnidadeAsync_RetornaUnidadeComValoresCorretos()
    {
        var nomeEsperado = Faker.Company.CompanyName(0);
        var fakeNow = Faker.Date.Recent().ToUniversalTime();
        var unidadeDto = new UnidadeCriacaoDtoBuilder().ComNome(nomeEsperado).Generate();

        _timeProviderMock.UtcNow.Returns(fakeNow);

        _unidadeRepositoryMock
            .InsereAsync(Arg.Any<Unidade>(), Arg.Any<CancellationToken>())
            .Returns(callInfo => callInfo.Arg<Unidade>());

        var resultado = await _sut.CriaAsync(unidadeDto, CancellationToken.None);

        resultado.ShouldNotBeNull();
        resultado.Nome.ShouldBe(nomeEsperado);
        resultado.CreatedAt.ShouldBe(fakeNow);
    }

    [Fact]
    public async Task CriaUnidadeAsync_RepassaCancellationTokenParaRepositorio()
    {
        var unidadeDto = new UnidadeCriacaoDtoBuilder().Generate();
        var cts = new CancellationTokenSource();

        await _sut.CriaAsync(unidadeDto, cts.Token);

        await _unidadeRepositoryMock.Received()
            .InsereAsync(Arg.Any<Unidade>(), cts.Token);
    }

    [Fact]
    public async Task ObtemTodosAsync_RetornaResultadoDoRepositorio()
    {
        var unidadesEsperadas = new UnidadeBuilder().Generate(3);

        var idsEsperados = unidadesEsperadas.Select(u => u.Id).ToList();
        var nomesEsperados = unidadesEsperadas.Select(u => u.Nome).ToList();
        var createdAtsEsperados = unidadesEsperadas.Select(u => u.CreatedAt).ToList();
        var updatedAtsEsperados = unidadesEsperadas.Select(u => u.UpdatedAt).ToList();

        _unidadeRepositoryMock
            .ObtemTodosAsync(Arg.Any<CancellationToken>())
            .Returns(unidadesEsperadas);

        var resultado = (await _sut.ObtemTodosAsync(CancellationToken.None)).ToList();

        resultado.Count.ShouldBe(unidadesEsperadas.Count);
        for (var i = 0; i < resultado.Count; i++)
        {
            resultado[i].Id.ShouldBe(idsEsperados[i]);
            resultado[i].Nome.ShouldBe(nomesEsperados[i]);
            resultado[i].CreatedAt.ShouldBe(createdAtsEsperados[i]);
            resultado[i].UpdatedAt.ShouldBe(updatedAtsEsperados[i]);
        }
    }

    [Fact]
    public async Task ObtemTodosAsync_QuandoVazio_RetornaColecaoVazia()
    {
        _unidadeRepositoryMock
            .ObtemTodosAsync(Arg.Any<CancellationToken>())
            .Returns([]);

        var resultado = await _sut.ObtemTodosAsync(CancellationToken.None);

        resultado.ShouldBeEmpty();
    }

    [Fact]
    public async Task ObtemAsync_RetornaResultadoDoRepositorio()
    {
        var unidadeEsperada = new UnidadeBuilder().Generate();

        var idEsperado = unidadeEsperada.Id;
        var nomeEsperado = unidadeEsperada.Nome;
        var createdAtEsperado = unidadeEsperada.CreatedAt;
        var updatedAtEsperado = unidadeEsperada.UpdatedAt;

        _unidadeRepositoryMock
            .ObtemAsync(idEsperado, Arg.Any<CancellationToken>())
            .Returns(unidadeEsperada);

        var resultado = await _sut.ObtemAsync(idEsperado, CancellationToken.None);

        resultado.ShouldNotBeNull();
        resultado.Id.ShouldBe(idEsperado);
        resultado.Nome.ShouldBe(nomeEsperado);
        resultado.CreatedAt.ShouldBe(createdAtEsperado);
        resultado.UpdatedAt.ShouldBe(updatedAtEsperado);
    }

    [Fact]
    public async Task ObtemAsync_QuandoNaoEncontrado_RetornaNull()
    {
        var idInexistente = Faker.Random.Guid();

        _unidadeRepositoryMock
            .ObtemAsync(idInexistente, Arg.Any<CancellationToken>())
            .Returns((Unidade?)null);

        var resultado = await _sut.ObtemAsync(idInexistente, CancellationToken.None);

        resultado.ShouldBeNull();
    }

    [Fact]
    public async Task AtualizaAsync_DefineUpdatedAtComHoraAtual()
    {
        var fakeNow = Faker.Date.Recent().ToUniversalTime();
        var unidade = new UnidadeBuilder().Generate();

        _timeProviderMock.UtcNow.Returns(fakeNow);

        _unidadeRepositoryMock
            .AtualizaAsync(Arg.Any<Unidade>(), Arg.Any<CancellationToken>())
            .Returns(callInfo => callInfo.Arg<Unidade>());

        var resultado = await _sut.AtualizaAsync(unidade, CancellationToken.None);

        resultado.ShouldNotBeNull();
        resultado.UpdatedAt.ShouldBe(fakeNow);
    }

    [Fact]
    public async Task AtualizaAsync_RetornaResultadoDoRepositorio()
    {
        var unidade = new UnidadeBuilder().Generate();
        var unidadeAtualizada = new UnidadeBuilder().Generate();

        var idEsperado = unidadeAtualizada.Id;
        var nomeEsperado = unidadeAtualizada.Nome;
        var createdAtEsperado = unidadeAtualizada.CreatedAt;
        var updatedAtEsperado = unidadeAtualizada.UpdatedAt;

        _unidadeRepositoryMock
            .AtualizaAsync(Arg.Any<Unidade>(), Arg.Any<CancellationToken>())
            .Returns(unidadeAtualizada);

        var resultado = await _sut.AtualizaAsync(unidade, CancellationToken.None);

        resultado.ShouldNotBeNull();
        resultado.Id.ShouldBe(idEsperado);
        resultado.Nome.ShouldBe(nomeEsperado);
        resultado.CreatedAt.ShouldBe(createdAtEsperado);
        resultado.UpdatedAt.ShouldBe(updatedAtEsperado);
    }

    [Fact]
    public async Task AtualizaAsync_RepassaCancellationTokenParaRepositorio()
    {
        var unidade = new UnidadeBuilder().Generate();
        var cts = new CancellationTokenSource();

        _unidadeRepositoryMock
            .AtualizaAsync(Arg.Any<Unidade>(), Arg.Any<CancellationToken>())
            .Returns(unidade);

        await _sut.AtualizaAsync(unidade, cts.Token);

        await _unidadeRepositoryMock.Received()
            .AtualizaAsync(unidade, cts.Token);
    }
}