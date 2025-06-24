namespace AEE_Plus.Domain.Entities.Turma;
public class TurmaEntityBuilder
{
    private long _id;
    private string _nome = string.Empty;
    private string _escola = string.Empty;
    private DateTime _dataCriacao = DateTime.UtcNow;
    private long _idProfessor;

    public TurmaEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public TurmaEntityBuilder WithNome(string nome)
    {
        _nome = nome;
        return this;
    }
    public TurmaEntityBuilder WithEscola(string escola)
    {
        _escola = escola;
        return this;
    }
    public TurmaEntityBuilder WithDataCriacao(DateTime dataCriacao)
    {
        _dataCriacao = dataCriacao;
        return this;
    }
    public TurmaEntityBuilder WithIdProfessor(long idProfessor)
    {
        _idProfessor = idProfessor;
        return this;
    }

    public TurmaEntity Build()
    {
        return new TurmaEntity(_id, _nome, _escola, _dataCriacao, _idProfessor);
    }
}
