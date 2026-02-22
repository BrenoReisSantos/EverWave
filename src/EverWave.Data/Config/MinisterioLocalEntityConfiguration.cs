using EverWave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverWave.Data.Config;

public class MinisterioLocalEntityConfiguration : IEntityTypeConfiguration<MinisterioLocal>
{
    public void Configure(EntityTypeBuilder<MinisterioLocal> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasAlternateKey(x => new { x.UnidadeId, x.MinisterioId });
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UnidadeId).IsRequired();
        builder.Property(x => x.MinisterioId).IsRequired();
        builder.HasOne(x => x.Ministerio).WithMany(x => x.MinisteriosLocais).HasForeignKey(x => x.MinisterioId);
        builder.HasOne(x => x.Unidade).WithMany(x => x.MinisteriosLocais).HasForeignKey(x => x.UnidadeId);
    }
}