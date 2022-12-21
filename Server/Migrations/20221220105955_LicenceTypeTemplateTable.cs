using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class LicenceTypeTemplateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenceTypeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenceTypeTemplates", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenceTypeTemplates");

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
                values: new object[] { "5dbb893c-3cf6-4bae-96ce-58bb7bc6c45f", "AQAAAAIAAYagAAAAELNuozA3eJKU2Gv7S3Ys1hsV4PCCgUglwetFl8sRTY0NH+ATPhUh5IrBZwypme8IeA==", "65edb285-68db-4d13-877f-4916c56d1e8c" });
        }
    }
}
