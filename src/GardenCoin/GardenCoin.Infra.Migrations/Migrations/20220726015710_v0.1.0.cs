using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenCoin.Infra.Migrations.Migrations
{
    public partial class v010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CORRETORA",
                columns: table => new
                {
                    ID_CORRETORA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ULTIMA_ATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CORRETORA", x => x.ID_CORRETORA);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_ATIVO",
                columns: table => new
                {
                    ID_TIPO_ATIVO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_ATIVO", x => x.ID_TIPO_ATIVO);
                });

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
                name: "TB_CARTEIRA",
                columns: table => new
                {
                    ID_CARTEIRA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VALOR_TOTAL = table.Column<double>(type: "float", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_CORRETORA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_USUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_BALANCO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorretoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CARTEIRA", x => x.ID_CARTEIRA);
                    table.ForeignKey(
                        name: "FK_TB_CARTEIRA_TB_CORRETORA_CorretoraId",
                        column: x => x.CorretoraId,
                        principalTable: "TB_CORRETORA",
                        principalColumn: "ID_CORRETORA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CARTEIRA_TB_CORRETORA_ID_CORRETORA",
                        column: x => x.ID_CORRETORA,
                        principalTable: "TB_CORRETORA",
                        principalColumn: "ID_CORRETORA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CARTEIRA_TB_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "TB_BALANCO",
                columns: table => new
                {
                    ID_BALANCO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VALOR_TOTAL = table.Column<double>(type: "float", nullable: false),
                    ID_CARTEIRA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarteiraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BALANCO", x => x.ID_BALANCO);
                    table.ForeignKey(
                        name: "FK_TB_BALANCO_TB_CARTEIRA_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "TB_CARTEIRA",
                        principalColumn: "ID_CARTEIRA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_BALANCO_TB_CARTEIRA_ID_CARTEIRA",
                        column: x => x.ID_CARTEIRA,
                        principalTable: "TB_CARTEIRA",
                        principalColumn: "ID_CARTEIRA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ATIVO",
                columns: table => new
                {
                    ID_ATIVO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALOR_UNITARIO = table.Column<double>(type: "float", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    ID_BALANCO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_TIPO_ATIVO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BalancoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoAtivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ATIVO", x => x.ID_ATIVO);
                    table.ForeignKey(
                        name: "FK_TB_ATIVO_TB_BALANCO_BalancoId",
                        column: x => x.BalancoId,
                        principalTable: "TB_BALANCO",
                        principalColumn: "ID_BALANCO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ATIVO_TB_BALANCO_ID_BALANCO",
                        column: x => x.ID_BALANCO,
                        principalTable: "TB_BALANCO",
                        principalColumn: "ID_BALANCO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ATIVO_TB_TIPO_ATIVO_ID_TIPO_ATIVO",
                        column: x => x.ID_TIPO_ATIVO,
                        principalTable: "TB_TIPO_ATIVO",
                        principalColumn: "ID_TIPO_ATIVO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ATIVO_TB_TIPO_ATIVO_TipoAtivoId",
                        column: x => x.TipoAtivoId,
                        principalTable: "TB_TIPO_ATIVO",
                        principalColumn: "ID_TIPO_ATIVO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CDB",
                columns: table => new
                {
                    ID_CDB = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALOR_BRUTO = table.Column<double>(type: "float", nullable: false),
                    VALOR_LIQUIDO = table.Column<double>(type: "float", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    ID_BALANCO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BalancoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CDB", x => x.ID_CDB);
                    table.ForeignKey(
                        name: "FK_TB_CDB_TB_BALANCO_BalancoId",
                        column: x => x.BalancoId,
                        principalTable: "TB_BALANCO",
                        principalColumn: "ID_BALANCO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CDB_TB_BALANCO_ID_BALANCO",
                        column: x => x.ID_BALANCO,
                        principalTable: "TB_BALANCO",
                        principalColumn: "ID_BALANCO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ATIVO_BalancoId",
                table: "TB_ATIVO",
                column: "BalancoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ATIVO_ID_BALANCO",
                table: "TB_ATIVO",
                column: "ID_BALANCO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ATIVO_ID_TIPO_ATIVO",
                table: "TB_ATIVO",
                column: "ID_TIPO_ATIVO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ATIVO_TipoAtivoId",
                table: "TB_ATIVO",
                column: "TipoAtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_BALANCO_CarteiraId",
                table: "TB_BALANCO",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_BALANCO_ID_CARTEIRA",
                table: "TB_BALANCO",
                column: "ID_CARTEIRA");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARTEIRA_CorretoraId",
                table: "TB_CARTEIRA",
                column: "CorretoraId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARTEIRA_ID_CORRETORA",
                table: "TB_CARTEIRA",
                column: "ID_CORRETORA");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARTEIRA_UsuarioId",
                table: "TB_CARTEIRA",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CDB_BalancoId",
                table: "TB_CDB",
                column: "BalancoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CDB_ID_BALANCO",
                table: "TB_CDB",
                column: "ID_BALANCO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ATIVO");

            migrationBuilder.DropTable(
                name: "TB_CDB");

            migrationBuilder.DropTable(
                name: "TB_LOGIN");

            migrationBuilder.DropTable(
                name: "TB_TIPO_ATIVO");

            migrationBuilder.DropTable(
                name: "TB_BALANCO");

            migrationBuilder.DropTable(
                name: "TB_CARTEIRA");

            migrationBuilder.DropTable(
                name: "TB_CORRETORA");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
