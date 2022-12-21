using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedLastStepColumnTableWorkFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LastStep",
                table: "WorkFlow",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastStep",
                table: "WorkFlow");
        }
    }
}
