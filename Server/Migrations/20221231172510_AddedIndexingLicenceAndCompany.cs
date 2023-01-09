using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexingLicenceAndCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0c67a07-7f2d-468b-84c6-c302cc5fb6a8", "AQAAAAIAAYagAAAAEOBFKNLaHfCHCTPcoflQtwtwkVZRBqts6BQCiTaJ8Mlkk4p3c/H4daC9u/zdEJXzIw==", "6636068b-5073-47c2-a731-88aa1fcc9b91" });

            migrationBuilder.CreateIndex(
                name: "IX_Licences_Id",
                table: "Licences",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Id",
                table: "Companies",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Licences_Id",
                table: "Licences");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Id",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "827951c3-736e-4eac-93eb-ccb0cedd54b0", "AQAAAAIAAYagAAAAEKD5UfIQqklVdtaK1iu2EOHpfFCG+ZUYetajr3y93PnVlnoJ2Kg4lTTo8NXQg0+5VQ==", "6fad0d1e-d189-47bd-8a51-98d8d3fcdaf6" });
        }
    }
}
