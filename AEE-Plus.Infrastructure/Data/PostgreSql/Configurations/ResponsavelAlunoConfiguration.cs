using AEE_Plus.Domain.Entities.ResponsavelAluno;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Configurations;
public class ResponsavelAlunoConfiguration : IEntityTypeConfiguration<ResponsavelAlunoEntity>
{
    public void Configure(EntityTypeBuilder<ResponsavelAlunoEntity> builder)
    {
        builder.HasKey(ra => ra.Id);

        builder.Property(ra => ra.GrauParentesco)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(ra => ra.DataVinculo)
            .IsRequired();

        builder.Property(ra => ra.IdResponsavel)
            .IsRequired();

        builder.Property(ra => ra.IdAluno)
            .IsRequired();

        builder.HasIndex(ra => new { ra.IdResponsavel, ra.IdAluno })
            .IsUnique();

        builder.HasOne(ra => ra.Responsavel)
               .WithMany(u => u.AlunosResponsaveis)
               .HasForeignKey(ra => ra.IdResponsavel)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ra => ra.Aluno)
               .WithMany(a => a.Responsaveis)
               .HasForeignKey(ra => ra.IdAluno)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
