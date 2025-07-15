using AEE_Plus.Domain.Entities.PAEE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Configurations;
public class PaeeConfiguration : IEntityTypeConfiguration<PaeeEntity>
{
    public void Configure(EntityTypeBuilder<PaeeEntity> builder)
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
               .WithOne(a => a.PAEE)
               .HasForeignKey<PaeeEntity>(p => p.IdAluno);
    }
}
