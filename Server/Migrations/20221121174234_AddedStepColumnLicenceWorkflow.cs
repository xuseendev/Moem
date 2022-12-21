using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedStepColumnLicenceWorkflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Step",
                table: "LicenceWorkFlows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Licences_CompanyId",
                table: "Licences",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licences_Companies_CompanyId",
                table: "Licences",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licences_Companies_CompanyId",
                table: "Licences");

            migrationBuilder.DropIndex(
                name: "IX_Licences_CompanyId",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "Step",
                table: "LicenceWorkFlows");
        }
    }
}
