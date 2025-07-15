using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class AddResponsaveisAndRanking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodigoAcessoEntity_Usuarios_IdUsuario",
                table: "CodigoAcessoEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CodigoAcessoEntity",
                table: "CodigoAcessoEntity");

            migrationBuilder.RenameTable(
                name: "CodigoAcessoEntity",
                newName: "CodigosAcesso");

            migrationBuilder.RenameIndex(
                name: "IX_CodigoAcessoEntity_IdUsuario",
                table: "CodigosAcesso",
                newName: "IX_CodigosAcesso_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_CodigoAcessoEntity_Codigo",
                table: "CodigosAcesso",
                newName: "IX_CodigosAcesso_Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CodigosAcesso",
                table: "CodigosAcesso",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RankingsJogos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pontuacao = table.Column<int>(type: "integer", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdJogo = table.Column<long>(type: "bigint", nullable: false),
                    IdAluno = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankingsJogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RankingsJogos_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RankingsJogos_Jogos_IdJogo",
                        column: x => x.IdJogo,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsaveisAlunos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GrauParentesco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DataVinculo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdResponsavel = table.Column<long>(type: "bigint", nullable: false),
                    IdAluno = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsaveisAlunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsaveisAlunos_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsaveisAlunos_Usuarios_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RankingsJogos_IdAluno",
                table: "RankingsJogos",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_RankingsJogos_IdJogo",
                table: "RankingsJogos",
                column: "IdJogo");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisAlunos_IdAluno",
                table: "ResponsaveisAlunos",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisAlunos_IdResponsavel_IdAluno",
                table: "ResponsaveisAlunos",
                columns: new[] { "IdResponsavel", "IdAluno" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CodigosAcesso_Usuarios_IdUsuario",
                table: "CodigosAcesso",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodigosAcesso_Usuarios_IdUsuario",
                table: "CodigosAcesso");

            migrationBuilder.DropTable(
                name: "RankingsJogos");

            migrationBuilder.DropTable(
                name: "ResponsaveisAlunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CodigosAcesso",
                table: "CodigosAcesso");

            migrationBuilder.RenameTable(
                name: "CodigosAcesso",
                newName: "CodigoAcessoEntity");

            migrationBuilder.RenameIndex(
                name: "IX_CodigosAcesso_IdUsuario",
                table: "CodigoAcessoEntity",
                newName: "IX_CodigoAcessoEntity_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_CodigosAcesso_Codigo",
                table: "CodigoAcessoEntity",
                newName: "IX_CodigoAcessoEntity_Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CodigoAcessoEntity",
                table: "CodigoAcessoEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CodigoAcessoEntity_Usuarios_IdUsuario",
                table: "CodigoAcessoEntity",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
