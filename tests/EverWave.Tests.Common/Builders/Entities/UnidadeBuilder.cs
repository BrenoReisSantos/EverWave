using Bogus;

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

    public UnidadeBuilder ComCreatedAt(DateTime createdAt)
    {
        RuleFor(x => x.CreatedAt, createdAt);
        return this;
    }

    public UnidadeBuilder ComId(Guid id)
    {
        RuleFor(x => x.Id, id);
        return this;
    }

    public UnidadeBuilder ComNome(string nome)
    {
        RuleFor(x => x.Nome, nome);
        return this;
    }
    
    public UnidadeBuilder ComUpdatedAt(DateTime updatedAt)
    {
        RuleFor(x => x.UpdatedAt, updatedAt);
        return this;
    }
}