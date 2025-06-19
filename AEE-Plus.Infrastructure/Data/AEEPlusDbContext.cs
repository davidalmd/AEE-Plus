using AEE_Plus.Domain.Entities.Aluno;
using AEE_Plus.Domain.Entities.ProtocoloConduta;
using AEE_Plus.Domain.Entities.Turma;
using AEE_Plus.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using System;

namespace AEE_Plus.Infrastructure.Data;

public class AEEPlusDbContext(DbContextOptions<AEEPlusDbContext> options) : DbContext(options)
{
    public DbSet<UsuarioEntity> Usuarios { get; set; }
    public DbSet<TurmaEntity> Turmas { get; set; }
    public DbSet<AlunoEntity> Alunos { get; set; }
    public DbSet<ProtocoloCondutaEntity> ProtocolosConduta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AEEPlusDbContext).Assembly);
    }
}
