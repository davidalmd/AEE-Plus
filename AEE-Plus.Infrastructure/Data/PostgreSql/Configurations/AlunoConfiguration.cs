using AEE_Plus.Domain.Entities.Aluno;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Configurations;
public class AlunoConfiguration : IEntityTypeConfiguration<AlunoEntity>
{
    public void Configure(EntityTypeBuilder<AlunoEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Nome)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(a => a.DataNascimento)
            .IsRequired();

        builder.Property(a => a.Sexo)
            .HasConversion<string>()
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(a => a.CID)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(a => a.NomeMae)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(a => a.IdTurma)
            .IsRequired();

        // Relationship
        builder.HasOne(a => a.Turma)
               .WithMany(t => t.Alunos)
               .HasForeignKey(a => a.IdTurma)
               .OnDelete(DeleteBehavior.Restrict); // Não deixa deletar uma turma que tenha alunos
    }
}
