using EverWave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EverWave.Data.Config;

public class CategoriaCargoEntityConfiguration : IEntityTypeConfiguration<CategoriaCargo>
{
    public void Configure(EntityTypeBuilder<CategoriaCargo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Descricao).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasMany(x => x.Cargos).WithOne(x => x.Categoria);
    }
}