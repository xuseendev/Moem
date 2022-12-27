using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedLicenceTemplateMorFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SignatureId",
                table: "LicenceTypeTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "LicenceTypeTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfa23fd-542d-4ade-951e-a3da08eff315",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb0aca2-2d5f-4466-b8df-52f12467afe5",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e89d44d4-0101-417a-a0c7-73f2cb8e00f6", "AQAAAAIAAYagAAAAEBCUNOGrEYHKsMYGau4KSxdenRF6W6qbpnA6/10SLfDTMw4eR47mUutLNaLwYwW8Mw==", "0b14ae5c-354b-4682-bdbe-c58e8ed887bf" });

            migrationBuilder.CreateIndex(
                name: "IX_LicenceTypeTemplates_SignatureId",
                table: "LicenceTypeTemplates",
                column: "SignatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenceTypeTemplates_Signatures_SignatureId",
                table: "LicenceTypeTemplates",
                column: "SignatureId",
                principalTable: "Signatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenceTypeTemplates_Signatures_SignatureId",
                table: "LicenceTypeTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LicenceTypeTemplates_SignatureId",
                table: "LicenceTypeTemplates");

            migrationBuilder.DropColumn(
                name: "SignatureId",
                table: "LicenceTypeTemplates");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "LicenceTypeTemplates");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfa23fd-542d-4ade-951e-a3da08eff315",
                column: "ConcurrencyStamp",
                value: "02c93165-97ff-439c-adb7-0f7ef85f7308");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb0aca2-2d5f-4466-b8df-52f12467afe5",
                column: "ConcurrencyStamp",
                value: "2fac193d-1741-4a40-a960-1533eac430ee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05eaa921-fb23-48fe-891d-a320d8c610cf", "AQAAAAEAACcQAAAAEHBEK2HkHKGJJe568wh+DQujPDTgcut8EAthFia9g1+8Erdol+Cjlzn74p/IMfawBg==", "2ce28faa-11ae-413b-8c14-d9f9c7619e30" });
        }
    }
}
