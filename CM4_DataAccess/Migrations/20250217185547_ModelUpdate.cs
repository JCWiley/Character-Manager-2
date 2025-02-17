using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM4_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Organizations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Goals",
                table: "Organizations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationID",
                table: "Organizations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PrimarySpeciesID",
                table: "Organizations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsDummy = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsDummy = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_LocationID",
                table: "Organizations",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_PrimarySpeciesID",
                table: "Organizations",
                column: "PrimarySpeciesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Locations_LocationID",
                table: "Organizations",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Species_PrimarySpeciesID",
                table: "Organizations",
                column: "PrimarySpeciesID",
                principalTable: "Species",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Locations_LocationID",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Species_PrimarySpeciesID",
                table: "Organizations");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_LocationID",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_PrimarySpeciesID",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "PrimarySpeciesID",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Organizations");
        }
    }
}
