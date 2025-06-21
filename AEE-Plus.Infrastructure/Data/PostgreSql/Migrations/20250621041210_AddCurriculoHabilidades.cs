using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class AddCurriculoHabilidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurriculosHabilidades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroDiagnostico = table.Column<int>(type: "integer", nullable: false),
                    NumeroArea = table.Column<int>(type: "integer", nullable: false),
                    NumeroPergunta = table.Column<int>(type: "integer", nullable: false),
                    Resposta = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    DataResposta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdAluno = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculosHabilidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculosHabilidades_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurriculosHabilidades_IdAluno",
                table: "CurriculosHabilidades",
                column: "IdAluno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurriculosHabilidades");
        }
    }
}
