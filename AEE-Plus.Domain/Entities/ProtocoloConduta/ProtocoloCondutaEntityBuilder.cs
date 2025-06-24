namespace AEE_Plus.Domain.Entities.ProtocoloConduta;
public class ProtocoloCondutaEntityBuilder
{
    private long _id;
    private string _conteudoResposta = string.Empty; // JSON
    private DateTime _dataPreenchimento = DateTime.UtcNow;
    private long _idAluno;

    public ProtocoloCondutaEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public ProtocoloCondutaEntityBuilder WithConteudoResposta(string conteudoResposta)
    {
        _conteudoResposta = conteudoResposta;
        return this;
    }
    public ProtocoloCondutaEntityBuilder WithDataPreenchimento(DateTime dataPreenchimento)
    {
        _dataPreenchimento = dataPreenchimento;
        return this;
    }
    public ProtocoloCondutaEntityBuilder WithIdAluno(long idAluno)
    {
        _idAluno = idAluno;
        return this;
    }
    
    public ProtocoloCondutaEntity Build()
    {
        return new ProtocoloCondutaEntity(_id, _conteudoResposta, _dataPreenchimento, _idAluno);
    }
}
