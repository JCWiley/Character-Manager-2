using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM4_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterOrganization");

            migrationBuilder.DropTable(
                name: "OrganizationOrganization");

            migrationBuilder.AddColumn<string>(
                name: "Child_Characters",
                table: "Organizations",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Child_Organizations",
                table: "Organizations",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Parent_Organizations",
                table: "Organizations",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Parent_Organizations",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Child_Characters",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Child_Organizations",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Parent_Organizations",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Parent_Organizations",
                table: "Characters");

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

            migrationBuilder.CreateTable(
                name: "OrganizationOrganization",
                columns: table => new
                {
                    MemberOrgsID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MembershipsID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationOrganization", x => new { x.MemberOrgsID, x.MembershipsID });
                    table.ForeignKey(
                        name: "FK_OrganizationOrganization_Organizations_MemberOrgsID",
                        column: x => x.MemberOrgsID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationOrganization_Organizations_MembershipsID",
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
                name: "IX_OrganizationOrganization_MembershipsID",
                table: "OrganizationOrganization",
                column: "MembershipsID");
        }
    }
}
