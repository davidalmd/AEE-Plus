using AEE_Plus.Domain.Enums;

namespace AEE_Plus.Domain.Entities.Usuario;
public class UsuarioEntityBuilder
{
    private long _id;
    private string _nome = string.Empty;
    private string _email = string.Empty;
    private string _senha = string.Empty;
    private PerfilUsuario _perfil;
    private StatusUsuario _status;
    private bool _primeiroAcesso;

    public UsuarioEntityBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
    public UsuarioEntityBuilder WithNome(string nome)
    {
        _nome = nome;
        return this;
    }
    public UsuarioEntityBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }
    public UsuarioEntityBuilder WithSenha(string senha)
    {
        _senha = senha;
        return this;
    }
    public UsuarioEntityBuilder WithPerfil(PerfilUsuario perfil)
    {
        _perfil = perfil;
        return this;
    }
    public UsuarioEntityBuilder WithStatus(StatusUsuario status)
    {
        _status = status;
        return this;
    }
    public UsuarioEntityBuilder WithPrimeiroAcesso(bool primeiroAcesso)
    {
        _primeiroAcesso = primeiroAcesso;
        return this;
    }

    public UsuarioEntity Build()
    {
        return new UsuarioEntity(_id, _nome, _email, _senha, _perfil, _status, _primeiroAcesso);
    }
}
