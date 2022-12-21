using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompletedOnLicenceWorkFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedOn",
                table: "LicenceWorkFlows",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfa23fd-542d-4ade-951e-a3da08eff315",
                column: "ConcurrencyStamp",
                value: "5f6769ab-c4db-462d-9a4d-d0894ba985e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb0aca2-2d5f-4466-b8df-52f12467afe5",
                column: "ConcurrencyStamp",
                value: "1f8f9aa0-4d4b-4ff8-9f95-21b9e37edfda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e74cbee-4175-438a-9d0b-b1011237bcdd", "AQAAAAEAACcQAAAAEBiSozVe7NborVBnQXi2r4UK8GRrYtstef+737tUh3eZUaWqCafNla8Ho29bVRoJ2g==", "b5d48215-a688-419a-a4b7-2a1e39cffb30" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedOn",
                table: "LicenceWorkFlows");

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
    }
}
