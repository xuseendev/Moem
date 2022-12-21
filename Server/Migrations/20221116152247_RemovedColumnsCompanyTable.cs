using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemovedColumnsCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_LicenceType_LicenceTypeId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_LicenceTypeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LicenceEndDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LicenceStartDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LicenceTypeId",
                table: "Companies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LicenceEndDate",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LicenceStartDate",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LicenceTypeId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_LicenceTypeId",
                table: "Companies",
                column: "LicenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_LicenceType_LicenceTypeId",
                table: "Companies",
                column: "LicenceTypeId",
                principalTable: "LicenceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
