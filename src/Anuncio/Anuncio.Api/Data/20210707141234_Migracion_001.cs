using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anuncio.Api.Data
{
    public partial class Migracion_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aviso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    tipoArchivo = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    tipoAviso = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    fechaFinalizacion = table.Column<DateTime>(type: "date", nullable: false),
                    fechaInicioDescripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    fechaFinalizacionDescripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    nombreArchivo = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    duracion = table.Column<int>(type: "int", nullable: false),
                    url = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    publicado = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Removed = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviso", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aviso");
        }
    }
}
