using AEE_Plus.Domain.Entities.PranchaComunicacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Configurations;
public class PranchaComunicacaoConfiguration : IEntityTypeConfiguration<PranchaComunicacaoEntity>
{
    public void Configure(EntityTypeBuilder<PranchaComunicacaoEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Cards)
            .HasColumnType("jsonb")
            .IsRequired();

        builder.Property(p => p.DataUltimaEdicao)
            .IsRequired();

        builder.Property(p => p.IdUsuario)
            .IsRequired();

        builder.HasOne(p => p.Usuario)
               .WithOne(u => u.PranchaComunicacao)
               .HasForeignKey<PranchaComunicacaoEntity>(p => p.IdUsuario)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
