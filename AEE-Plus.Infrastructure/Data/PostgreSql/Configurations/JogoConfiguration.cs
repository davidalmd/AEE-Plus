using AEE_Plus.Domain.Entities.Jogo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Configurations;
public class JogoConfiguration : IEntityTypeConfiguration<JogoEntity>
{
    public void Configure(EntityTypeBuilder<JogoEntity> builder)
    {
        builder.HasKey(j => j.Id);

        builder.Property(j => j.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(j => j.Descricao)
            .HasMaxLength(500);

        builder.Property(j => j.PontuacaoAtiva)
            .IsRequired();
    }
}
