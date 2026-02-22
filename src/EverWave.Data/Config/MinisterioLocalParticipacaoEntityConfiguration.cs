using EverWave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverWave.Data.Config;

public class MinisterioLocalParticipacaoEntityConfiguration : IEntityTypeConfiguration<MinisterioLocalParticipacao>
{
    public void Configure(EntityTypeBuilder<MinisterioLocalParticipacao> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasAlternateKey(x => new { x.MinisterioLocalId, x.MembroId, x.CargoId });

        builder.HasOne(x => x.MinisterioLocal).WithMany(x => x.ParticipacoesMinisterios).HasForeignKey(x => x.MinisterioLocalId);
    }
}