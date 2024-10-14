using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticari.Entities.Migrations
{
    /// <inheritdoc />
    public partial class Gsm116 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gsm116s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gsm = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gsm116s", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gsm116s_Id",
                table: "Gsm116s",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gsm116s");
        }
    }
}
