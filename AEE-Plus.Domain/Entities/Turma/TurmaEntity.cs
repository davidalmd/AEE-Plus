using AEE_Plus.Domain.Entities.Aluno;
using AEE_Plus.Domain.Entities.Usuario;

namespace AEE_Plus.Domain.Entities.Turma;
public class TurmaEntity
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Escola { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }

    // Chave Estrangeira
    public long IdProfessor { get; set; }

    // Proriedade de Navegação
    public virtual UsuarioEntity Professor { get; set; } = null!;
    public virtual ICollection<AlunoEntity> Alunos { get; set; } = new List<AlunoEntity>();

    public TurmaEntity(long id, string nome, string escola, DateTime dataCriacao, long idProfessor)
    {
        this.Id = id;
        this.Nome = nome;
        this.Escola = escola;
        this.DataCriacao = dataCriacao;
        this.IdProfessor = idProfessor;
    }
}
