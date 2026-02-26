using EverWave.Domain.Common;
using EverWave.Domain.Entities;
using EverWave.Domain.Repository;
using EverWave.Domain.Services;
using EverWave.Services;
using EverWave.Tests.Common;
using EverWave.Tests.Common.Builders.Dtos.HttpIn;

using NSubstitute;

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
    public async Task CriaUnidadeAsync_ChamaInsereUnidadeAsyncComParametrosCorretos()
    {
        var nomeEsperado = Faker.Company.CompanyName(0);
        var unidadeFake = new UnidadeCriacaoDtoBuilder().ComNome(nomeEsperado).Generate();
        var fakeNow = Faker.Date.Recent();
        _timeProviderMock.UtcNow.Returns(fakeNow);

        await _sut.CriaUnidadeAsync(unidadeFake, CancellationToken.None);

        await _unidadeRepositoryMock.Received()
            .InsereAsync(Arg.Is<Unidade>(u => u.Nome == nomeEsperado && u.CreatedAt == fakeNow),
                Arg.Any<CancellationToken>());
    }
}