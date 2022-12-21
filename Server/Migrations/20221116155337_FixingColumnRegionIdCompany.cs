using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixingColumnRegionIdCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Region_RegoinId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "RegoinId",
                table: "Companies",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_RegoinId",
                table: "Companies",
                newName: "IX_Companies_RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Region_RegionId",
                table: "Companies",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Region_RegionId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Companies",
                newName: "RegoinId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_RegionId",
                table: "Companies",
                newName: "IX_Companies_RegoinId");

            migrationBuilder.AddColumn<int>(
                name: "Region",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Region_RegoinId",
                table: "Companies",
                column: "RegoinId",
                principalTable: "Region",
                principalColumn: "Id");
        }
    }
}
