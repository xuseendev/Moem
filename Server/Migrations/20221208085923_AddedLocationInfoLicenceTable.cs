using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedLocationInfoLicenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Licences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Licences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Licences",
                type: "int",
                nullable: true);

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
                name: "IX_Licences_AreaId",
                table: "Licences",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_CityId",
                table: "Licences",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_RegionId",
                table: "Licences",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licences_Areas_AreaId",
                table: "Licences",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Licences_Cities_CityId",
                table: "Licences",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Licences_Region_RegionId",
                table: "Licences",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licences_Areas_AreaId",
                table: "Licences");

            migrationBuilder.DropForeignKey(
                name: "FK_Licences_Cities_CityId",
                table: "Licences");

            migrationBuilder.DropForeignKey(
                name: "FK_Licences_Region_RegionId",
                table: "Licences");

            migrationBuilder.DropIndex(
                name: "IX_Licences_AreaId",
                table: "Licences");

            migrationBuilder.DropIndex(
                name: "IX_Licences_CityId",
                table: "Licences");

            migrationBuilder.DropIndex(
                name: "IX_Licences_RegionId",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Licences");

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
    }
}
