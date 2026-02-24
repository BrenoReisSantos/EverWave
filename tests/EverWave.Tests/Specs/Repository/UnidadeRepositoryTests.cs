using EverWave.Domain.Repository;
using EverWave.Repository;
using EverWave.Tests.Common;
using EverWave.Tests.Common.Builders.Entities;

using Shouldly;

namespace EverWave.Tests.Specs.Repository;

public class UnidadeRepositoryTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _databaseFixture;
    private readonly IUnidadeRepository _sut;

    public UnidadeRepositoryTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
        _sut = new UnidadeRepository(_databaseFixture.Context);
    }

    [Fact]
    public async Task Test()
    {
        var unidade = new UnidadeBuilder().ComoNovaEntidade().Generate();

        var novaUnidade = await _sut.InsereUnidadeAsync(unidade, CancellationToken.None);
    }
}