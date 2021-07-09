using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaReproduccionAudiencia.Api.Data
{
    public partial class Migracion_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audiencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroAudiencia = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    TipoAudiencia = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Despacho = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    NumeroExpediente = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    EstadoAudiencia = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Removed = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audiencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parte",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AudienciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    TipoParte = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    TipoPersona = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Removed = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parte_Audiencia_AudienciaId",
                        column: x => x.AudienciaId,
                        principalTable: "Audiencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parte_AudienciaId",
                table: "Parte",
                column: "AudienciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parte");

            migrationBuilder.DropTable(
                name: "Audiencia");
        }
    }
}
