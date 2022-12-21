using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAreaIdCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Areas_AreaId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AreaId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfa23fd-542d-4ade-951e-a3da08eff315",
                column: "ConcurrencyStamp",
                value: "3f9780de-428c-41c8-bdb8-9c146b078ae3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb0aca2-2d5f-4466-b8df-52f12467afe5",
                column: "ConcurrencyStamp",
                value: "59822076-a950-45e3-a0ff-1969e5816b39");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15ada1ba-4a0b-4038-8ccb-fb40a9548248", "AQAAAAEAACcQAAAAED8kn0JZgyj8+Gs3tMYFdtDM7aNWLd3pGhHCBJGHzD5OhtuItEMlHg4bPJITw2gbtQ==", "12fd9d4f-2bc2-4b34-b0fe-d069b011f26b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfa23fd-542d-4ade-951e-a3da08eff315",
                column: "ConcurrencyStamp",
                value: "ae70962f-f25b-421f-9f37-577f18759068");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb0aca2-2d5f-4466-b8df-52f12467afe5",
                column: "ConcurrencyStamp",
                value: "aa81e3d6-af8d-4507-a61b-402c18f1da07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf360213-4a69-4871-bcf7-e9a236d1c425", "AQAAAAEAACcQAAAAEOEW7OwW6nBZkhO00LpGSnxXQl5xeBXVINOxVRqGkUYgUIGKBbzAVPWATpmJpF258g==", "823438fa-da67-4981-84a0-fd94f1455bcc" });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AreaId",
                table: "Companies",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Areas_AreaId",
                table: "Companies",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
