using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedStartedOnLicenceWorkFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartedOn",
                table: "LicenceWorkFlows",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfa23fd-542d-4ade-951e-a3da08eff315",
                column: "ConcurrencyStamp",
                value: "6ae09049-1ac1-4a24-92ff-7855f465f7a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb0aca2-2d5f-4466-b8df-52f12467afe5",
                column: "ConcurrencyStamp",
                value: "788bff72-c58d-4c0a-aeaf-24ef4c69bbf0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd566e73-7592-498f-be96-8c4fdc69b372", "AQAAAAEAACcQAAAAEHqsmBWFKNaEeyu00Yvvuujqd5oH9Oj2sJh2cpYs/4iyLblr8wxBqdEx9TkSjC4fnQ==", "f56dc7f2-7894-4c12-8da4-7f12491535bf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartedOn",
                table: "LicenceWorkFlows");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfa23fd-542d-4ade-951e-a3da08eff315",
                column: "ConcurrencyStamp",
                value: "d675b70c-44a1-40d7-a074-30bb3809bf72");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb0aca2-2d5f-4466-b8df-52f12467afe5",
                column: "ConcurrencyStamp",
                value: "972c11ab-68b3-4741-9c6c-906a38b45ec5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf773968-2101-4ae4-bf7c-3645795d1c5b", "AQAAAAEAACcQAAAAEGwkUw/aU4pLgBnRJvz3TXRIhBZHBExqjVWxmOkdTuCCDW+wj/mG/LDEgW7nWINEWA==", "fc2adb8d-ff70-4f08-88fa-695d2d21c0f2" });
        }
    }
}
