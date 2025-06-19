using AEE_Plus.Domain.Entities.Aluno;

namespace AEE_Plus.Domain.Entities.ProtocoloConduta;
public class ProtocoloCondutaEntity
{
    public long Id { get; set; }
    public string ConteudoResposta { get; set; } = string.Empty; // JSON
    public DateTime DataPreenchimento { get; set; }

    // Chave Estrangeira
    public long IdAluno { get; set; }

    // Propriedade de Navegação
    public virtual AlunoEntity Aluno { get; set; } = null!;

    public ProtocoloCondutaEntity(long id, string conteudoResposta, DateTime dataPreenchimento, long idAluno)
    {
        this.Id = id;
        this.ConteudoResposta = conteudoResposta;
        this.DataPreenchimento = dataPreenchimento;
        this.IdAluno = idAluno;
    }
}
