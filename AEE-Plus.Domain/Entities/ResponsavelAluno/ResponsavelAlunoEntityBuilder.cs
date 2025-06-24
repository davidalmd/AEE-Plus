namespace AEE_Plus.Domain.Entities.ResponsavelAluno;
public class ResponsavelAlunoEntityBuilder
{
    private long _id;
    private string _grauParentesco = string.Empty;
    private DateTime _dataVinculo = DateTime.Now;
    private long _idResponsavel;
    private long _idAluno;

    public ResponsavelAlunoEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public ResponsavelAlunoEntityBuilder WithGrauParentesco(string grauParentesco)
    {
        _grauParentesco = grauParentesco;
        return this;
    }
    public ResponsavelAlunoEntityBuilder WithDataVinculo(DateTime dataVinculo)
    {
        _dataVinculo = dataVinculo;
        return this;
    }
    public ResponsavelAlunoEntityBuilder WithIdResponsavel(long idResponsavel)
    {
        _idResponsavel = idResponsavel;
        return this;
    }
    public ResponsavelAlunoEntityBuilder WithIdAluno(long idAluno)
    {
        _idAluno = idAluno;
        return this;
    }

    public ResponsavelAlunoEntity Build()
    {
        return new ResponsavelAlunoEntity(_id, _grauParentesco, _dataVinculo, _idResponsavel, _idAluno);
    }
}
