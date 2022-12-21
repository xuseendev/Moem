using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4cfa23fd-542d-4ade-951e-a3da08eff315", "c56d1033-c66a-48fc-ba25-5908bf8067d6", "Administrator", "ADMINISTRATOR" },
                    { "bbb0aca2-2d5f-4466-b8df-52f12467afe5", "ec9c8cea-4bbf-43a1-a363-b434b6eb89f2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Region", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName" },
                values: new object[] { "2419fb85-daf3-47a6-9af3-1c1bc5dfd248", 0, null, "73954726-d5c7-4b2e-8bc7-0b8ea54773c2", "admin@moem.com", false, "System", "Admin", false, null, "ADMIN@MOEM.COM", "ADMIN", "AQAAAAEAACcQAAAAEO34wridwsT0wAIHb81mDLUvua7GjdTJUdRpCjgRMnw0AuD51Iziq4A7Kx9mw2V0tg==", null, false, null, "62f6f8e0-e0f3-428f-b935-41ddc744cd20", false, null, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4cfa23fd-542d-4ade-951e-a3da08eff315", "2419fb85-daf3-47a6-9af3-1c1bc5dfd248" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb0aca2-2d5f-4466-b8df-52f12467afe5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4cfa23fd-542d-4ade-951e-a3da08eff315", "2419fb85-daf3-47a6-9af3-1c1bc5dfd248" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfa23fd-542d-4ade-951e-a3da08eff315");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2419fb85-daf3-47a6-9af3-1c1bc5dfd248");
        }
    }
}
