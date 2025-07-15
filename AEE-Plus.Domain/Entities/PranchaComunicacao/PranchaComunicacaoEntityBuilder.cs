namespace AEE_Plus.Domain.Entities.PranchaComunicacao;
public class PranchaComunicacaoEntityBuilder
{
    private long _id;
    private string _cards = string.Empty; // JSON
    private DateTime _dataUltimaEdicao = DateTime.UtcNow;
    private long _idUsuario;

    public PranchaComunicacaoEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public PranchaComunicacaoEntityBuilder WithCards(string cards)
    {
        _cards = cards;
        return this;
    }
    public PranchaComunicacaoEntityBuilder WithDataUltimaEdicao(DateTime dataUltimaEdicao)
    {
        _dataUltimaEdicao = dataUltimaEdicao;
        return this;
    }
    public PranchaComunicacaoEntityBuilder WithIdUsuario(long idUsuario)
    {
        _idUsuario = idUsuario;
        return this;
    }

    public PranchaComunicacaoEntity Build()
    {
        return new PranchaComunicacaoEntity(_id, _cards, _dataUltimaEdicao, _idUsuario);
    }
}
