using Bogus;
using Bogus.Extensions;

using EverWave.Domain.Entities;

namespace EverWave.Tests.Common.Builders.Entities;

public sealed class UnidadeBuilder : Faker<Unidade>
{
    public UnidadeBuilder()
    {
        RuleFor(x => x.Nome, f => f.Company.CompanyName(0));
        RuleFor(x => x.Id, f => f.Random.Guid());
        RuleFor(x => x.CreatedAt, f => f.Date.Past().ToUniversalTime());
        RuleFor(x => x.UpdatedAt, f => f.Date.Past().ToUniversalTime().OrNull(f, 0.5f));
    }

    public UnidadeBuilder ComoNovaEntidade()
    {
        RuleFor(x => x.Id, Guid.Empty);
        return this;
    }
}