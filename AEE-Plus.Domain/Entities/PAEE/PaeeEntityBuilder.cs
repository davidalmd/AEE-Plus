namespace AEE_Plus.Domain.Entities.PAEE;
public class PaeeEntityBuilder
{
    private long _id;
    private string _conteudoResposta = string.Empty; // JSON
    private DateTime _dataPreenchimento = DateTime.UtcNow;
    private long _idAluno;

    public PaeeEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public PaeeEntityBuilder WithConteudoResposta(string conteudoResposta)
    {
        _conteudoResposta = conteudoResposta;
        return this;
    }
    public PaeeEntityBuilder WithDataPreenchimento(DateTime dataPreenchimento)
    {
        _dataPreenchimento = dataPreenchimento;
        return this;
    }
    public PaeeEntityBuilder WithIdAluno(long idAluno)
    {
        _idAluno = idAluno;
        return this;
    }

    public PaeeEntity Build()
    {
        return new PaeeEntity(_id, _conteudoResposta, _dataPreenchimento, _idAluno);
    }
}
