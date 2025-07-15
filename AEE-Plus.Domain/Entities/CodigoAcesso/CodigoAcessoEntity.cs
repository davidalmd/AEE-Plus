using AEE_Plus.Domain.Entities.Usuario;

namespace AEE_Plus.Domain.Entities.CodigoAcesso;
public class CodigoAcessoEntity
{
    public long Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public DateTime Expiracao { get; set; }
    public bool Utilizado { get; set; }
    public DateTime DataEnvio { get; set; }

    // Chave Estrangeira
    public long IdUsuario { get; set; }

    // Propriedade de Navegação
    public virtual UsuarioEntity Usuario { get; set; } = null!;

    public CodigoAcessoEntity(long id, string codigo, DateTime expiracao, bool utilizado, DateTime dataEnvio, long idUsuario)
    {
        Id = id;
        Codigo = codigo;
        Expiracao = expiracao;
        Utilizado = utilizado;
        DataEnvio = dataEnvio;
        IdUsuario = idUsuario;
    }
}
