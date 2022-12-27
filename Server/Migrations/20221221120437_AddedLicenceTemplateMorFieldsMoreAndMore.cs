using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedLicenceTemplateMorFieldsMoreAndMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LicenceTypeId",
                table: "LicenceTypeTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "827951c3-736e-4eac-93eb-ccb0cedd54b0", "AQAAAAIAAYagAAAAEKD5UfIQqklVdtaK1iu2EOHpfFCG+ZUYetajr3y93PnVlnoJ2Kg4lTTo8NXQg0+5VQ==", "6fad0d1e-d189-47bd-8a51-98d8d3fcdaf6" });

            migrationBuilder.CreateIndex(
                name: "IX_LicenceTypeTemplates_LicenceTypeId",
                table: "LicenceTypeTemplates",
                column: "LicenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenceTypeTemplates_LicenceType_LicenceTypeId",
                table: "LicenceTypeTemplates",
                column: "LicenceTypeId",
                principalTable: "LicenceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenceTypeTemplates_LicenceType_LicenceTypeId",
                table: "LicenceTypeTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LicenceTypeTemplates_LicenceTypeId",
                table: "LicenceTypeTemplates");

            migrationBuilder.DropColumn(
                name: "LicenceTypeId",
                table: "LicenceTypeTemplates");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "202ce642-eebd-4526-ad4e-203c6f02e87a", "AQAAAAIAAYagAAAAEKO4nZ+RwSGafPbkTiF0WGSZv4VOwUlF+UBTlRbdv2Z9vOsB2lQNd9JxdYgR52Cbxg==", "07161b7c-2e75-4e70-b140-ed27f68d0900" });
        }
    }
}
