namespace AEE_Plus.Domain.Entities.RankingJogo;
public class RankingJogoEntityBuilder
{
    private long _id;
    private int _pontuacao;
    private DateTime _dataRegistro;
    private long _idJogo;
    private long _idAluno;

    public RankingJogoEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public RankingJogoEntityBuilder WithPontuacao(int pontuacao)
    {
        _pontuacao = pontuacao;
        return this;
    }
    public RankingJogoEntityBuilder WithDataRegistro(DateTime dataRegistro)
    {
        _dataRegistro = dataRegistro;
        return this;
    }
    public RankingJogoEntityBuilder WithIdJogo(long idJogo)
    {
        _idJogo = idJogo;
        return this;
    }
    public RankingJogoEntityBuilder WithIdAluno(long idAluno)
    {
        _idAluno = idAluno;
        return this;
    }

    public RankingJogoEntity Build()
    {
        return new RankingJogoEntity(_id, _pontuacao, _dataRegistro, _idJogo, _idAluno);
    }
}
