using AEE_Plus.Domain.Entities.Usuario;

namespace AEE_Plus.Domain.Entities.PranchaComunicacao;
public class PranchaComunicacaoEntity
{
    public long Id { get; set; }
    public string Cards { get; set; } = string.Empty; // JSON
    public DateTime DataUltimaEdicao { get; set; }

    // Chave Estrangeira
    public long IdUsuario { get; set; }

    // Propriedade de Navegação
    public virtual UsuarioEntity Usuario { get; set; } = null!;

    public PranchaComunicacaoEntity(long id, string cards, DateTime dataUltimaEdicao, long idUsuario)
    {
        this.Id = id;
        this.Cards = cards;
        this.DataUltimaEdicao = dataUltimaEdicao;
        this.IdUsuario = idUsuario;
    }
}
