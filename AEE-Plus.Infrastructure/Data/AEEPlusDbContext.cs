using AEE_Plus.Domain.Entities.Aluno;
using AEE_Plus.Domain.Entities.CodigoAcesso;
using AEE_Plus.Domain.Entities.CurriculoHabilidades;
using AEE_Plus.Domain.Entities.Jogo;
using AEE_Plus.Domain.Entities.PAEE;
using AEE_Plus.Domain.Entities.PranchaComunicacao;
using AEE_Plus.Domain.Entities.ProtocoloConduta;
using AEE_Plus.Domain.Entities.RankingJogo;
using AEE_Plus.Domain.Entities.ResponsavelAluno;
using AEE_Plus.Domain.Entities.Turma;
using AEE_Plus.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;

namespace AEE_Plus.Infrastructure.Data;

public class AEEPlusDbContext(DbContextOptions<AEEPlusDbContext> options) : DbContext(options)
{
    public DbSet<UsuarioEntity> Usuarios { get; set; }
    public DbSet<TurmaEntity> Turmas { get; set; }
    public DbSet<AlunoEntity> Alunos { get; set; }
    public DbSet<ProtocoloCondutaEntity> ProtocolosConduta { get; set; }
    public DbSet<CurriculoHabilidadesEntity> CurriculosHabilidades { get; set; }
    public DbSet<PaeeEntity> PAEE { get; set; }
    public DbSet<JogoEntity> Jogos { get; set; }
    public DbSet<PranchaComunicacaoEntity> PranchasComunicacao { get; set; }
    public DbSet<CodigoAcessoEntity> CodigosAcesso { get; set; }
    public DbSet<ResponsavelAlunoEntity> ResponsaveisAlunos { get; set; }
    public DbSet<RankingJogoEntity> RankingsJogos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AEEPlusDbContext).Assembly);
    }
}
