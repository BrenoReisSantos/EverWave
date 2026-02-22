using EverWave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverWave.Data.Config;

public class ContatoEntityConfiguration : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Ddd).IsRequired();
        builder.Property(x => x.Ddi).IsRequired();
        builder.Property(x => x.Telefone).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasOne(x => x.Membro).WithMany(x => x.Contatos);
    }
}