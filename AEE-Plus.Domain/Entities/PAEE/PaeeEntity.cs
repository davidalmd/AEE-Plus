using AEE_Plus.Domain.Entities.Aluno;

namespace AEE_Plus.Domain.Entities.PAEE;
public class PaeeEntity
{
    public long Id { get; set; }
    public string ConteudoResposta { get; set; } = string.Empty; // JSON
    public DateTime DataPreenchimento { get; set; }

    // Chave Estrangeira
    public long IdAluno { get; set; }

    // Propriedade de Navegação
    public virtual AlunoEntity Aluno { get; set; } = null!;

    public PaeeEntity(long id, string conteudoResposta, DateTime dataPreenchimento, long idAluno)
    {
        this.Id = id;
        this.ConteudoResposta = conteudoResposta;
        this.DataPreenchimento = dataPreenchimento;
        this.IdAluno = idAluno;
    }
}
