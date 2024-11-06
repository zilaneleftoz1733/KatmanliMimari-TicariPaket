using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticari.Entities.Migrations.Turkiye
{
    /// <inheritdoc />
    public partial class turkiyedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_il",
                columns: table => new
                {
                    il_id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    il_ad = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true, collation: "Turkish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_iller", x => x.il_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ilce",
                columns: table => new
                {
                    ilce_id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    il_id = table.Column<short>(type: "smallint", nullable: false),
                    ilce_ad = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, collation: "Turkish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ilce", x => x.ilce_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mahalle",
                columns: table => new
                {
                    mahalle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    semt_id = table.Column<short>(type: "smallint", nullable: false),
                    mahalle_ad = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, collation: "Turkish_CI_AS"),
                    pk_id = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_mahalle", x => x.mahalle_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_pk",
                columns: table => new
                {
                    pk_id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kod = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true, defaultValueSql: "((0))", collation: "Turkish_CI_AS")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_semt",
                columns: table => new
                {
                    semt_id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ilce_id = table.Column<short>(type: "smallint", nullable: false),
                    semt_ad = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, collation: "Turkish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_semtler", x => x.semt_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ilce",
                table: "tbl_ilce",
                columns: new[] { "ilce_id", "il_id" });

            migrationBuilder.CreateIndex(
                name: "IX_mahalle",
                table: "tbl_mahalle",
                columns: new[] { "mahalle_id", "semt_id" });

            migrationBuilder.CreateIndex(
                name: "IX_semt",
                table: "tbl_semt",
                columns: new[] { "semt_id", "ilce_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_il");

            migrationBuilder.DropTable(
                name: "tbl_ilce");

            migrationBuilder.DropTable(
                name: "tbl_mahalle");

            migrationBuilder.DropTable(
                name: "tbl_pk");

            migrationBuilder.DropTable(
                name: "tbl_semt");
        }
    }
}
