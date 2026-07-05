using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AhvaPrueba.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposContratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposContratacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    CorreoPrincipal = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CorreoSecundario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TelefonoMovil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TelefonoSecundario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TipoContratacionId = table.Column<int>(type: "int", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoPerfilUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Institucion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContadorValidacionesFallidas = table.Column<int>(type: "int", nullable: false),
                    FechaBloqueo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Sexos_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposContratacion_TipoContratacionId",
                        column: x => x.TipoContratacionId,
                        principalTable: "TiposContratacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TiposDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "TiposContratacion",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Fijo" },
                    { 2, "Temporal" },
                    { 3, "Contratista" }
                });

            migrationBuilder.InsertData(
                table: "TiposDocumento",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Cédula de Identidad" },
                    { 2, "Pasaporte" },
                    { 3, "RIF" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "ContadorValidacionesFallidas", "CorreoPrincipal", "CorreoSecundario", "FechaBloqueo", "FechaContratacion", "FechaNacimiento", "FotoPerfilUrl", "Institucion", "Nacionalidad", "Nombres", "NumeroDocumento", "PasswordHash", "PrimerApellido", "SegundoApellido", "SexoId", "TelefonoMovil", "TelefonoSecundario", "TipoContratacionId", "TipoDocumentoId", "Titulo", "Username" },
                values: new object[] { 1, 0, "keylor.calderon.dev@gmail.com", null, null, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default-profile.png", "Universidad de Costa Rica", "Costarricense", "Keylor", "V-12345678", "$2a$11$WN3E2qRBt2ve1J6Gdp5z1uxsy/CqBV/W.Sutldr0rmM0yLEYVePMG", "Calderon", "Vega", 1, "506-12345678", null, 1, 1, "Ingeniero de Sistemas", "KeylorCalderon" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SexoId",
                table: "Usuarios",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoContratacionId",
                table: "Usuarios",
                column: "TipoContratacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoDocumentoId",
                table: "Usuarios",
                column: "TipoDocumentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "TiposContratacion");

            migrationBuilder.DropTable(
                name: "TiposDocumento");
        }
    }
}
