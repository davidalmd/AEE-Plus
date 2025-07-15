using AEE_Plus.Domain.Entities.ProtocoloConduta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Configurations;
public class ProtocoloCondutaConfiguration : IEntityTypeConfiguration<ProtocoloCondutaEntity>
{
    public void Configure(EntityTypeBuilder<ProtocoloCondutaEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ConteudoResposta)
            .HasColumnType("jsonb")
            .IsRequired();

        builder.Property(p => p.DataPreenchimento)
            .IsRequired();

        builder.Property(p => p.IdAluno)
            .IsRequired();

        builder.HasOne(p => p.Aluno)
            .WithOne(a => a.ProtocoloConduta)
            .HasForeignKey<ProtocoloCondutaEntity>(p => p.IdAluno);
    }
}
