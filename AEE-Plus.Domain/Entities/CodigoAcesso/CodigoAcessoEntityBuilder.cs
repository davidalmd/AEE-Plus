namespace AEE_Plus.Domain.Entities.CodigoAcesso;
public class CodigoAcessoEntityBuilder
{
    private long _id;
    private string _codigo = string.Empty;
    private DateTime _expiracao = DateTime.UtcNow.AddDays(1); // Default to 1 day from now
    private bool _utilizado = false;
    private DateTime _dataEnvio = DateTime.UtcNow; // Default to now
    private long _idUsuario;

    public CodigoAcessoEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public CodigoAcessoEntityBuilder WithCodigo(string codigo)
    {
        _codigo = codigo;
        return this;
    }
    public CodigoAcessoEntityBuilder WithExpiracao(DateTime expiracao)
    {
        _expiracao = expiracao;
        return this;
    }
    public CodigoAcessoEntityBuilder WithUtilizado(bool utilizado)
    {
        _utilizado = utilizado;
        return this;
    }
    public CodigoAcessoEntityBuilder WithDataEnvio(DateTime dataEnvio)
    {
        _dataEnvio = dataEnvio;
        return this;
    }
    public CodigoAcessoEntityBuilder WithIdUsuario(long idUsuario)
    {
        _idUsuario = idUsuario;
        return this;
    }

    public CodigoAcessoEntity Build()
    {
        return new CodigoAcessoEntity(_id, _codigo, _expiracao, _utilizado, _dataEnvio, _idUsuario);
    }
}
