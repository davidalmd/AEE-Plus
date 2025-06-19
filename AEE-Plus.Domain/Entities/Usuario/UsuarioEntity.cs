using AEE_Plus.Domain.Entities.Turma;
using AEE_Plus.Domain.Enums;

namespace AEE_Plus.Domain.Entities.Usuario
{
    public class UsuarioEntity
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public PerfilUsuario Perfil { get; set; }
        public StatusUsuario Status { get; set; }
        public bool PrimeiroAcesso { get; set; }

        // Propriedade de Navegação
         public virtual ICollection<TurmaEntity> Turmas { get; set; } = new List<TurmaEntity>();

        public UsuarioEntity(long id, string nome, string email, string senha, PerfilUsuario perfil, StatusUsuario status, bool primeiroAcesso)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Perfil = perfil;
            this.Status = status;
            this.PrimeiroAcesso = primeiroAcesso;
        }
    }
}
