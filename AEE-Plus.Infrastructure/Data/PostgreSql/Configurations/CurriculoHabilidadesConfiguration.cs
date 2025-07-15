using AEE_Plus.Domain.Entities.CurriculoHabilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Configurations;
public class CurriculoHabilidadesConfiguration : IEntityTypeConfiguration<CurriculoHabilidadesEntity>
{
    public void Configure(EntityTypeBuilder<CurriculoHabilidadesEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.NumeroDiagnostico)
            .IsRequired();

        builder.Property(c => c.NumeroArea)
            .IsRequired();

        builder.Property(c => c.NumeroPergunta)
            .IsRequired();

        builder.Property(c => c.Resposta)
            .HasConversion<string>()
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(c => c.DataResposta)
            .IsRequired();

        builder.Property(c => c.IdAluno)
            .IsRequired();

        builder.HasOne(c => c.Aluno)
               .WithMany(a => a.CurriculoHabilidades)
               .HasForeignKey(c => c.IdAluno)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
