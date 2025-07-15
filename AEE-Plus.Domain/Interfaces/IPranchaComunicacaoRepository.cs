using AEE_Plus.Domain.Entities.PranchaComunicacao;

namespace AEE_Plus.Domain.Interfaces;

public interface IPranchaComunicacaoRepository
{
    Task<PranchaComunicacaoEntity?> GetByIdAsync(long id);
    Task<PranchaComunicacaoEntity?> GetByUsuarioIdAsync(long usuarioId);
    Task AddAsync(PranchaComunicacaoEntity prancha);
    void Update(PranchaComunicacaoEntity prancha);
    void Delete(PranchaComunicacaoEntity prancha);
    Task<bool> SaveChangesAsync();
}
