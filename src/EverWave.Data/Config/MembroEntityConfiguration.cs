using EverWave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverWave.Data.Config;

public class MembroEntityConfiguration : IEntityTypeConfiguration<Membro>
{
    public void Configure(EntityTypeBuilder<Membro> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasOne(x => x.Unidade).WithMany(x => x.Membros);
        builder.HasMany(x => x.Contatos).WithOne(x => x.Membro);
    }
}