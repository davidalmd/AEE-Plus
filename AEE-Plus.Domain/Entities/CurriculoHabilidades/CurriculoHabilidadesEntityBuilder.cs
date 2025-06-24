using AEE_Plus.Domain.Enums;

namespace AEE_Plus.Domain.Entities.CurriculoHabilidades;
public class CurriculoHabilidadesEntityBuilder
{
    private long _id;
    private int _numeroDiagnostico;
    private int _numeroArea;
    private int _numeroPergunta;
    private RespostaHabilidade _resposta;
    private DateTime _dataResposta;
    private long _idAluno;

    public CurriculoHabilidadesEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public CurriculoHabilidadesEntityBuilder WithNumeroDiagnostico(int numeroDiagnostico)
    {
        _numeroDiagnostico = numeroDiagnostico;
        return this;
    }
    public CurriculoHabilidadesEntityBuilder WithNumeroArea(int numeroArea)
    {
        _numeroArea = numeroArea;
        return this;
    }
    public CurriculoHabilidadesEntityBuilder WithNumeroPergunta(int numeroPergunta)
    {
        _numeroPergunta = numeroPergunta;
        return this;
    }
    public CurriculoHabilidadesEntityBuilder WithResposta(RespostaHabilidade resposta)
    {
        _resposta = resposta;
        return this;
    }
    public CurriculoHabilidadesEntityBuilder WithDataResposta(DateTime dataResposta)
    {
        _dataResposta = dataResposta;
        return this;
    }
    public CurriculoHabilidadesEntityBuilder WithIdAluno(long idAluno)
    {
        _idAluno = idAluno;
        return this;
    }

    public CurriculoHabilidadesEntity Build()
    {
        return new CurriculoHabilidadesEntity(_id, _numeroDiagnostico, _numeroArea, _numeroPergunta, _resposta, _dataResposta, _idAluno);
    }
}
