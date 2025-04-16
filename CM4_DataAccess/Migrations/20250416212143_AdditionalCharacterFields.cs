using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM4_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalCharacterFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Goals",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Location",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Species",
                table: "Characters",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Species",
                table: "Characters");
        }
    }
}
