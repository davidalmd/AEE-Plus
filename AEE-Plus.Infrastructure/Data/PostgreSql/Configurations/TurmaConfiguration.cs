using AEE_Plus.Domain.Entities.Turma;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Configurations;
public class TurmaConfiguration : IEntityTypeConfiguration<TurmaEntity>
{
    public void Configure(EntityTypeBuilder<TurmaEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Escola)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(t => t.DataCriacao)
            .IsRequired();

        builder.Property(t => t.IdProfessor)
            .IsRequired();

        builder.HasOne(t => t.Professor)
               .WithMany(u => u.Turmas)
               .HasForeignKey(t => t.IdProfessor)
               .OnDelete(DeleteBehavior.Restrict); // Evita deletar um professor que tenha turmas
    }
}
