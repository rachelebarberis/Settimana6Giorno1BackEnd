using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Settimana6Giorno1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataDiNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Cognome", "DataDiNascita", "Email", "Nome" },
                values: new object[,]
                {
                    { new Guid("9d5e3b7c-2a4f-41d8-bf6c-7e8a1d9c0f2e"), "Braghin", new DateTime(2000, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "silvia.braghin@gmail.com", "Silvia" },
                    { new Guid("b1c0d0f2-3a7b-4f8d-9b6c-0e5e2d8c3f4a"), "Barberis", new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "rachele.barberis@gmail.com", "Rachele" },
                    { new Guid("e7f4a9d1-5b3c-489a-8f21-1c6d9e7f2b3a"), "Turiaci", new DateTime(2000, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "vittorio.turiaci@gmail.com", "Vittorio" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
