using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenCoin.Auth.Infra.Migrations.Migrations
{
    public partial class _20220630_Auth_v010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOBRENOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_LOGIN",
                columns: table => new
                {
                    EMAIL = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID_USUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LOGIN", x => new { x.ID_USUARIO, x.EMAIL });
                    table.ForeignKey(
                        name: "FK_TB_LOGIN_TB_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_LOGIN");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
