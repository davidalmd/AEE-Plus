using AEE_Plus.Domain.Entities.CodigoAcesso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Configurations;
public class CodigoAcessoConfiguration : IEntityTypeConfiguration<CodigoAcessoEntity>
{
    public void Configure(EntityTypeBuilder<CodigoAcessoEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Codigo)
            .HasMaxLength(7)
            .IsRequired();

        builder.Property(c => c.Expiracao)
            .IsRequired();

        builder.Property(c => c.Utilizado)
            .IsRequired();

        builder.Property(c => c.DataEnvio)
            .IsRequired();

        builder.Property(c => c.IdUsuario)
            .IsRequired();

        builder.HasIndex(c => c.Codigo)
            .IsUnique();

        builder.HasOne(c => c.Usuario)
               .WithOne(u => u.CodigoAcesso)
               .HasForeignKey<CodigoAcessoEntity>(c => c.IdUsuario)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
