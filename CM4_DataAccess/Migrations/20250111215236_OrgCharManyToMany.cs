using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM4_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrgCharManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OrganizationID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Organizations_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CharacterOrganization",
                columns: table => new
                {
                    MembersID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MembershipsID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterOrganization", x => new { x.MembersID, x.MembershipsID });
                    table.ForeignKey(
                        name: "FK_CharacterOrganization_Characters_MembersID",
                        column: x => x.MembersID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterOrganization_Organizations_MembershipsID",
                        column: x => x.MembershipsID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterOrganization_MembershipsID",
                table: "CharacterOrganization",
                column: "MembershipsID");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationID",
                table: "Organizations",
                column: "OrganizationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterOrganization");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
