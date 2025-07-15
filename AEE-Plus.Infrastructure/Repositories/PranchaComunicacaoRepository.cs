using AEE_Plus.Domain.Entities.PranchaComunicacao;
using AEE_Plus.Domain.Interfaces;
using AEE_Plus.Infrastructure.Data;
using AEE_Plus.Infrastructure.Data.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace AEE_Plus.Infrastructure.Repositories;

public class PranchaComunicacaoRepository : IPranchaComunicacaoRepository
{
    private readonly AEEPlusDbContext _context;

    public PranchaComunicacaoRepository(AEEPlusDbContext context)
    {
        _context = context;
    }

    public async Task<PranchaComunicacaoEntity?> GetByIdAsync(long id)
    {
        return await _context.PranchasComunicacao.FindAsync(id);
    }

    public async Task<PranchaComunicacaoEntity?> GetByUsuarioIdAsync(long usuarioId)
    {
        return await _context.PranchasComunicacao
            .FirstOrDefaultAsync(p => p.IdUsuario == usuarioId);
    }

    public async Task AddAsync(PranchaComunicacaoEntity prancha)
    {
        await _context.PranchasComunicacao.AddAsync(prancha);
    }

    public void Update(PranchaComunicacaoEntity prancha)
    {
        _context.Entry(prancha).State = EntityState.Modified;
    }

    public void Delete(PranchaComunicacaoEntity prancha)
    {
        _context.PranchasComunicacao.Remove(prancha);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
