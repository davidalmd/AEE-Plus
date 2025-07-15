using AEE_Plus.Domain.Enums;

namespace AEE_Plus.Domain.Entities.Aluno;
public class AlunoEntityBuilder
{
    private long _id;
    private string _nome = string.Empty;
    private DateTime _dataNascimento = DateTime.MinValue;
    private SexoAluno _sexo = SexoAluno.Masculino;
    private string _cid = string.Empty;
    private string _nomeMae = string.Empty;
    private long _idTurma;

    public AlunoEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public AlunoEntityBuilder WithNome(string nome)
    {
        _nome = nome;
        return this;
    }
    public AlunoEntityBuilder WithDataNascimento(DateTime dataNascimento)
    {
        _dataNascimento = dataNascimento;
        return this;
    }
    public AlunoEntityBuilder WithSexo(SexoAluno sexo)
    {
        _sexo = sexo;
        return this;
    }
    public AlunoEntityBuilder WithCID(string cid)
    {
        _cid = cid;
        return this;
    }
    public AlunoEntityBuilder WithNomeMae(string nomeMae)
    {
        _nomeMae = nomeMae;
        return this;
    }
    public AlunoEntityBuilder WithIdTurma(long idTurma)
    {
        _idTurma = idTurma;
        return this;
    }

    public AlunoEntity Build()
    {
        return new AlunoEntity(_id, _nome, _dataNascimento, _sexo, _cid, _nomeMae, _idTurma);
    }
}
