using AEE_Plus.Domain.Entities.CurriculoHabilidades;
using AEE_Plus.Domain.Entities.PAEE;
using AEE_Plus.Domain.Entities.ProtocoloConduta;
using AEE_Plus.Domain.Entities.RankingJogo;
using AEE_Plus.Domain.Entities.ResponsavelAluno;
using AEE_Plus.Domain.Entities.Turma;
using AEE_Plus.Domain.Enums;

namespace AEE_Plus.Domain.Entities.Aluno;
public class AlunoEntity
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public SexoAluno Sexo { get; set; }
    public string CID { get; set; } = string.Empty;
    public string NomeMae { get; set; } = string.Empty;

    // Chave Estrangeira
    public long IdTurma { get; set; }

    // Propriedade de Navegação
    public virtual TurmaEntity Turma { get; set; } = null!;
    public virtual ProtocoloCondutaEntity ProtocoloConduta { get; set; } = null!;
    public virtual ICollection<CurriculoHabilidadesEntity> CurriculoHabilidades { get; set; } = new List<CurriculoHabilidadesEntity>();
    public virtual PaeeEntity PAEE { get; set; } = null!;
    public virtual ICollection<ResponsavelAlunoEntity> Responsaveis { get; set; } = new List<ResponsavelAlunoEntity>();
    public virtual ICollection<RankingJogoEntity> RankingsJogo { get; set; } = new List<RankingJogoEntity>();

    public AlunoEntity(long id, string nome, DateTime dataNascimento, SexoAluno sexo, string CID, string nomeMae, long idTurma)
    {
        this.Id = id;
        this.Nome = nome;
        this.DataNascimento = dataNascimento;
        this.Sexo = sexo;
        this.CID = CID;
        this.NomeMae = nomeMae;
        this.IdTurma = idTurma;
    }
}
