using AEE_Plus.Domain.Entities.Usuario;

namespace AEE_Plus.Domain.Entities.Turma;
public class TurmaEntity
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Escola { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }

    // Chave Estrangeira
    public Guid IdProfessor { get; set; }

    // Proriedade de Navegação
    public virtual UsuarioEntity Professor { get; set; } = null!;
}
