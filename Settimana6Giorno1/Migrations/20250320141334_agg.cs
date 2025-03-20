using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Settimana6Giorno1.Migrations
{
    /// <inheritdoc />
    public partial class agg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedAd",
                table: "Students",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("9d5e3b7c-2a4f-41d8-bf6c-7e8a1d9c0f2e"),
                columns: new[] { "CreatedAd", "UserId" },
                values: new object[] { new DateOnly(1, 1, 1), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("b1c0d0f2-3a7b-4f8d-9b6c-0e5e2d8c3f4a"),
                columns: new[] { "CreatedAd", "UserId" },
                values: new object[] { new DateOnly(1, 1, 1), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e7f4a9d1-5b3c-489a-8f21-1c6d9e7f2b3a"),
                columns: new[] { "CreatedAd", "UserId" },
                values: new object[] { new DateOnly(1, 1, 1), null });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedAd",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");
        }
    }
}
