using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedLicenceTemplateMorFieldsMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowCordinate",
                table: "LicenceTypeTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "202ce642-eebd-4526-ad4e-203c6f02e87a", "AQAAAAIAAYagAAAAEKO4nZ+RwSGafPbkTiF0WGSZv4VOwUlF+UBTlRbdv2Z9vOsB2lQNd9JxdYgR52Cbxg==", "07161b7c-2e75-4e70-b140-ed27f68d0900" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowCordinate",
                table: "LicenceTypeTemplates");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e89d44d4-0101-417a-a0c7-73f2cb8e00f6", "AQAAAAIAAYagAAAAEBCUNOGrEYHKsMYGau4KSxdenRF6W6qbpnA6/10SLfDTMw4eR47mUutLNaLwYwW8Mw==", "0b14ae5c-354b-4682-bdbe-c58e8ed887bf" });
        }
    }
}
