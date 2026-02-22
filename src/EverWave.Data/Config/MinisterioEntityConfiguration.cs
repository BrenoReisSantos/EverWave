using EverWave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverWave.Data.Config;

public class MinisterioEntityConfiguration : IEntityTypeConfiguration<Ministerio>
{
    public void Configure(EntityTypeBuilder<Ministerio> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

    }
}