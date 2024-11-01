using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticari.Entities.Migrations
{
    /// <inheritdoc />
    public partial class photopath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 10, 31, 14, 25, 5, 278, DateTimeKind.Local).AddTicks(5663));

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 10, 31, 14, 25, 5, 278, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 10, 31, 14, 25, 5, 278, DateTimeKind.Local).AddTicks(5669));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 10, 31, 11, 30, 29, 109, DateTimeKind.Local).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 10, 31, 11, 30, 29, 109, DateTimeKind.Local).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 10, 31, 11, 30, 29, 109, DateTimeKind.Local).AddTicks(7475));
        }
    }
}
