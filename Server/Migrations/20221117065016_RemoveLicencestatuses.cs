using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLicencestatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenceStatus");

            migrationBuilder.AddColumn<int>(
                name: "LicenceId",
                table: "LicenceStatuses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicenceStatuses_LicenceId",
                table: "LicenceStatuses",
                column: "LicenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenceStatuses_Licences_LicenceId",
                table: "LicenceStatuses",
                column: "LicenceId",
                principalTable: "Licences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenceStatuses_Licences_LicenceId",
                table: "LicenceStatuses");

            migrationBuilder.DropIndex(
                name: "IX_LicenceStatuses_LicenceId",
                table: "LicenceStatuses");

            migrationBuilder.DropColumn(
                name: "LicenceId",
                table: "LicenceStatuses");

            migrationBuilder.CreateTable(
                name: "LicenceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenceStatus", x => x.Id);
                });
        }
    }
}
