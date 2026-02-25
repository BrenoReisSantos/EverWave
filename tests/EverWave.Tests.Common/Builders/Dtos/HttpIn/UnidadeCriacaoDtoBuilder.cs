using Bogus;

using EverWave.Domain.Dtos.HttpIn;

namespace EverWave.Tests.Common.Builders.Dtos.HttpIn;

public class UnidadeCriacaoDtoBuilder : Faker<UnidadeCriacaoDto>
{
    public UnidadeCriacaoDtoBuilder()
    {
        RuleFor(x => x.Nome, f => f.Company.CompanyName(0));
    }

    public UnidadeCriacaoDtoBuilder ComNome(string nome)
    {
        RuleFor(x => x.Nome, nome);
        return this;
    }
}