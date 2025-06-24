using AEE_Plus.Domain.Entities.Aluno;
using AEE_Plus.Domain.Entities.Usuario;

namespace AEE_Plus.Domain.Entities.ResponsavelAluno;
public class ResponsavelAlunoEntity
{
    public long Id { get; set; }
    public string GrauParentesco { get; set; } = string.Empty;
    public DateTime DataVinculo { get; set; }

    // Chaves Estrangeiras
    public long IdResponsavel { get; set; }
    public long IdAluno { get; set; }

    // Propriedades de Navegação
    public virtual UsuarioEntity Responsavel { get; set; } = null!;
    public virtual AlunoEntity Aluno { get; set; } = null!;

    public ResponsavelAlunoEntity(long id, string grauParentesco, DateTime dataVinculo, long idResponsavel, long idAluno)
    {
        Id = id;
        GrauParentesco = grauParentesco;
        DataVinculo = dataVinculo;
        IdResponsavel = idResponsavel;
        IdAluno = idAluno;
    }
}
