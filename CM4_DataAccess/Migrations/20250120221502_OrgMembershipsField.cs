using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM4_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrgMembershipsField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Organizations_OrganizationID",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_OrganizationID",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "OrganizationID",
                table: "Organizations");

            // Disable foreign key constraints temporarily
            migrationBuilder.Sql("PRAGMA foreign_keys = OFF;", suppressTransaction: true);

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

            // Re-enable foreign key constraints
            migrationBuilder.Sql("PRAGMA foreign_keys = ON;", suppressTransaction: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationOrganization_MembershipsID",
                table: "OrganizationOrganization",
                column: "MembershipsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationOrganization");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationID",
                table: "Organizations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationID",
                table: "Organizations",
                column: "OrganizationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Organizations_OrganizationID",
                table: "Organizations",
                column: "OrganizationID",
                principalTable: "Organizations",
                principalColumn: "ID");
        }
    }
}
