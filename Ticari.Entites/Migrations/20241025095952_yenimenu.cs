using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticari.Entities.Migrations
{
    /// <inheritdoc />
    public partial class yenimenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 10, 25, 12, 59, 51, 926, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ControllerName", "CreateDate", "MenuName" },
                values: new object[] { "Product", new DateTime(2024, 10, 25, 12, 59, 51, 926, DateTimeKind.Local).AddTicks(811), "Product" });

            migrationBuilder.InsertData(
                table: "Menuler",
                columns: new[] { "Id", "ActionName", "AreaName", "ClassName", "ControllerName", "CreateDate", "CssName", "IconName", "MenuName", "OrderNo", "ParentMenuId", "RoleId" },
                values: new object[] { 3, "Index", "Admin", "far fa-circle nav-icon", "Account", new DateTime(2024, 10, 25, 12, 59, 51, 926, DateTimeKind.Local).AddTicks(814), "", null, "Users", null, null, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 10, 25, 12, 50, 49, 824, DateTimeKind.Local).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ControllerName", "CreateDate", "MenuName" },
                values: new object[] { "Home", new DateTime(2024, 10, 25, 12, 50, 49, 824, DateTimeKind.Local).AddTicks(7599), "Home" });
        }
    }
}
