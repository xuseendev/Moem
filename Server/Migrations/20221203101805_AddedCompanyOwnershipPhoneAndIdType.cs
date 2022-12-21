﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompanyOwnershipPhoneAndIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdType",
                table: "CompanyOwnerships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "CompanyOwnerships",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdType",
                table: "CompanyOwnerships");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "CompanyOwnerships");
        }
    }
}
