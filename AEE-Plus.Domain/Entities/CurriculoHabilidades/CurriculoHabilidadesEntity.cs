using AEE_Plus.Domain.Entities.Aluno;
using AEE_Plus.Domain.Enums;

namespace AEE_Plus.Domain.Entities.CurriculoHabilidades;
public class CurriculoHabilidadesEntity
{
    public long Id { get; set; }
    public int NumeroDiagnostico { get; set; }
    public int NumeroArea { get; set; }
    public int NumeroPergunta { get; set; }
    public RespostaHabilidade Resposta { get; set; }
    public DateTime DataResposta { get; set; }

    // Chave Estrangeira
    public long IdAluno { get; set; }

    // Propriedade de Navegação
    public virtual AlunoEntity Aluno { get; set; } = null!;

    public CurriculoHabilidadesEntity(long id, int numeroDiagnostico, int numeroArea, int numeroPergunta, RespostaHabilidade resposta, DateTime dataResposta, long idAluno)
    {
        this.Id = id;
        this.NumeroDiagnostico = numeroDiagnostico;
        this.NumeroArea = numeroArea;
        this.NumeroPergunta = numeroPergunta;
        this.Resposta = resposta;
        this.DataResposta = dataResposta;
        this.IdAluno = idAluno;
    }
}
