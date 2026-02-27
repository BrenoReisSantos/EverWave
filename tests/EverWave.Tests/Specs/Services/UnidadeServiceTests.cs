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

        _unidadeRepositoryMock
            .InsereAsync(Arg.Any<Unidade>(), Arg.Any<CancellationToken>())
            .Returns(unidadeEsperada);

        var resultado = await _sut.CriaAsync(unidadeDto, CancellationToken.None);

        resultado.ShouldBe(unidadeEsperada);
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
    public async Task CriaUnidadeAsync_QuandoRepositorioRetornaNull_RetornaNull()
    {
        var unidadeDto = new UnidadeCriacaoDtoBuilder().Generate();

        _unidadeRepositoryMock
            .InsereAsync(Arg.Any<Unidade>(), Arg.Any<CancellationToken>())
            .Returns((Unidade?)null);

        var resultado = await _sut.CriaAsync(unidadeDto, CancellationToken.None);

        resultado.ShouldBeNull();
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
}