using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM4_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrgLocationSpeciesRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Locations_LocationID",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Species_PrimarySpeciesID",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_LocationID",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_PrimarySpeciesID",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "IsDummy",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "IsDummy",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "IsDummy",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "IsDummy",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "PrimarySpeciesID",
                table: "Organizations",
                newName: "PrimarySpecies");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Organizations",
                newName: "Location");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrimarySpecies",
                table: "Organizations",
                newName: "PrimarySpeciesID");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Organizations",
                newName: "LocationID");

            migrationBuilder.AddColumn<bool>(
                name: "IsDummy",
                table: "Species",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDummy",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDummy",
                table: "Locations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDummy",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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
    }
}
