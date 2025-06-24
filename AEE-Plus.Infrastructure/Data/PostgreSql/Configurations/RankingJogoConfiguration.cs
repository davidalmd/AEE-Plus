using AEE_Plus.Domain.Entities.RankingJogo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Configurations;
public class RankingJogoConfiguration : IEntityTypeConfiguration<RankingJogoEntity>
{
    public void Configure(EntityTypeBuilder<RankingJogoEntity> builder)
    {
        builder.HasKey(rj => rj.Id);

        builder.Property(rj => rj.Pontuacao)
            .IsRequired();

        builder.Property(rj => rj.DataRegistro)
            .IsRequired();

        builder.Property(rj => rj.IdJogo)
            .IsRequired();

        builder.Property(rj => rj.IdAluno)
            .IsRequired();

        builder.HasOne(rj => rj.Jogo)
               .WithMany(j => j.Rankings)
               .HasForeignKey(rj => rj.IdJogo)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rj => rj.Aluno)
               .WithMany(a => a.RankingsJogo)
               .HasForeignKey(rj => rj.IdAluno)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
