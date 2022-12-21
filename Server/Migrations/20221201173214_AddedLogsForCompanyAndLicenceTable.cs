using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedLogsForCompanyAndLicenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Logs");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Logs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LicenceId",
                table: "Logs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_CompanyId",
                table: "Logs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LicenceId",
                table: "Logs",
                column: "LicenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Companies_CompanyId",
                table: "Logs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Licences_LicenceId",
                table: "Logs",
                column: "LicenceId",
                principalTable: "Licences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Companies_CompanyId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Licences_LicenceId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_CompanyId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_LicenceId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "LicenceId",
                table: "Logs");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
