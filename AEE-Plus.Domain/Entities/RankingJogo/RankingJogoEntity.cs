using AEE_Plus.Domain.Entities.Aluno;
using AEE_Plus.Domain.Entities.Jogo;

namespace AEE_Plus.Domain.Entities.RankingJogo;
public class RankingJogoEntity
{
    public long Id { get; set; }
    public int Pontuacao { get; set; }
    public DateTime DataRegistro { get; set; }

    // Chaves Estrangeiras
    public long IdJogo { get; set; }
    public long IdAluno { get; set; }

    // Propriedades de Navegação
    public virtual JogoEntity Jogo { get; set; } = null!;
    public virtual AlunoEntity Aluno { get; set; } = null!;

    public RankingJogoEntity(long id, int pontuacao, DateTime dataRegistro, long idJogo, long idAluno)
    {
        Id = id;
        Pontuacao = pontuacao;
        DataRegistro = dataRegistro;
        IdJogo = idJogo;
        IdAluno = idAluno;
    }
}
