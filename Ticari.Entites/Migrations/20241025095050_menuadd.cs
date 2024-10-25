using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ticari.Entities.Migrations
{
    /// <inheritdoc />
    public partial class menuadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menuler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: true),
                    ParentMenuId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menuler_Menuler_ParentMenuId",
                        column: x => x.ParentMenuId,
                        principalTable: "Menuler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menuler_Roller_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roller",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Menuler",
                columns: new[] { "Id", "ActionName", "AreaName", "ClassName", "ControllerName", "CreateDate", "CssName", "IconName", "MenuName", "OrderNo", "ParentMenuId", "RoleId" },
                values: new object[,]
                {
                    { 1, "Index", "Admin", "far fa-circle nav-icon", "Home", new DateTime(2024, 10, 25, 12, 50, 49, 824, DateTimeKind.Local).AddTicks(7595), "", null, "Home", null, null, 3 },
                    { 2, "Index", "Admin", "far fa-circle nav-icon", "Home", new DateTime(2024, 10, 25, 12, 50, 49, 824, DateTimeKind.Local).AddTicks(7599), "", null, "Home", null, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menuler_Id",
                table: "Menuler",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menuler_ParentMenuId",
                table: "Menuler",
                column: "ParentMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menuler_RoleId",
                table: "Menuler",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menuler");
        }
    }
}
