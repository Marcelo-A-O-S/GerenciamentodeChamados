using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamentodechamados.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chamados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tecnico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nivelPrioridade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataDeConclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipoDeManutenção = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chamados", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chamados");
        }
    }
}
