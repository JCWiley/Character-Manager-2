using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM4_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CharacterFieldUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Goals",
                table: "Characters",
                newName: "Quirks");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Birthplace",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Birthplace",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "Quirks",
                table: "Characters",
                newName: "Goals");
        }
    }
}
