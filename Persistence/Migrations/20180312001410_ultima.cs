using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.Migrations
{
    public partial class ultima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "publicaciones");

            migrationBuilder.CreateTable(
                name: "medias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duracion = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Estreno = table.Column<DateTime>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Temporadas = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medias");

            migrationBuilder.CreateTable(
                name: "publicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonaId = table.Column<int>(nullable: false),
                    contenido = table.Column<string>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: false),
                    foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publicaciones", x => x.Id);
                });
        }
    }
}
