using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedTaskActualOwnerLicenceWorkFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskActualOwner",
                table: "LicenceWorkFlows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfa23fd-542d-4ade-951e-a3da08eff315",
                column: "ConcurrencyStamp",
                value: "5defb5cf-4b04-40bd-bc45-e66ffd150222");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb0aca2-2d5f-4466-b8df-52f12467afe5",
                column: "ConcurrencyStamp",
                value: "7772f934-23b1-44c1-b477-bcb59c42399c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "006c3703-8d26-4bc3-a5af-188da1f6233b", "AQAAAAEAACcQAAAAEO/sJdBGTbgDdB8DlwySYnwXLaPmWZ9Za8jlQv9ilaX/aj/Fi1kyONNEzqLUyOT8pw==", "a7078331-a5e9-4f25-8d91-01de7ed5bb0f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskActualOwner",
                table: "LicenceWorkFlows");

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
    }
}
