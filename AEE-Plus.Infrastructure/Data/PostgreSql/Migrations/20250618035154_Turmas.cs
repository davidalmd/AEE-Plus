using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEE_Plus.Infrastructure.Data.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Turmas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioEntity",
                table: "UsuarioEntity");

            migrationBuilder.RenameTable(
                name: "UsuarioEntity",
                newName: "Usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Escola = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdProfessor = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Usuarios_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_IdProfessor",
                table: "Turmas",
                column: "IdProfessor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "UsuarioEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioEntity",
                table: "UsuarioEntity",
                column: "Id");
        }
    }
}
