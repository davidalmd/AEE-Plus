using AEE_Plus.Domain.Entities.RankingJogo;

namespace AEE_Plus.Domain.Entities.Jogo;
public class JogoEntity
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool PontuacaoAtiva { get; set; }

    // Propriedade de Navegação
    public virtual ICollection<RankingJogoEntity> Rankings { get; set; } = new List<RankingJogoEntity>();

    public JogoEntity(long id, string nome, string descricao, bool pontuacaoAtiva)
    {
        this.Id = id;
        this.Nome = nome;
        this.Descricao = descricao;
        this.PontuacaoAtiva = pontuacaoAtiva;
    }
}
