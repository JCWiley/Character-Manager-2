using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM4_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MoreOrgFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Leader",
                table: "Organizations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quirks",
                table: "Organizations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Leader",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Quirks",
                table: "Organizations");
        }
    }
}
