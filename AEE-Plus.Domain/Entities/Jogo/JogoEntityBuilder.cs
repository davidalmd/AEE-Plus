namespace AEE_Plus.Domain.Entities.Jogo;
public class JogoEntityBuilder
{
    private long _id;
    private string _nome = string.Empty;
    private string _descricao = string.Empty;
    private bool _pontuacaoAtiva;

    public JogoEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public JogoEntityBuilder WithNome(string nome)
    {
        _nome = nome;
        return this;
    }
    public JogoEntityBuilder WithDescricao(string descricao)
    {
        _descricao = descricao;
        return this;
    }
    public JogoEntityBuilder WithPontuacaoAtiva(bool pontuacaoAtiva)
    {
        _pontuacaoAtiva = pontuacaoAtiva;
        return this;
    }

    public JogoEntity Build()
    {
        return new JogoEntity(_id, _nome, _descricao, _pontuacaoAtiva);
    }
}
