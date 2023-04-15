using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvinciaNET.SelfManagement.Common.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrgCostCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgCostCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgDirections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgDirections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AdGroupDisplayName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AdGroupAccountName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgMailDatabaseGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgMailDatabaseGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: false),
                    DirectionId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgSections_OrgCostCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "OrgCostCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgSections_OrgDirections_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "OrgDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgStructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    OrgUnit = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: false),
                    MailDatabaseGroupId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgStructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgStructures_OrgMailDatabaseGroups_MailDatabaseGroupId",
                        column: x => x.MailDatabaseGroupId,
                        principalTable: "OrgMailDatabaseGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgStructures_OrgSections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "OrgSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgMemberships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdGroupDisplayName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AdGroupAccountName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    StructureId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgMemberships_OrgStructures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "OrgStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdUserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SamAccountName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UserPrincipalName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    GivenName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    SurName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    MembershipId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdUserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdUserAccounts_OrgLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "OrgLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdUserAccounts_OrgMemberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "OrgMemberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdUserAccountProvisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdUserAccountId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    HasError = table.Column<bool>(type: "bit", nullable: false),
                    Error = table.Column<string>(type: "varchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdUserAccountProvisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdUserAccountProvisions_AdUserAccounts_AdUserAccountId",
                        column: x => x.AdUserAccountId,
                        principalTable: "AdUserAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdUserAccountProvisions_AdUserAccountId",
                table: "AdUserAccountProvisions",
                column: "AdUserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AdUserAccounts_LocationId",
                table: "AdUserAccounts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdUserAccounts_MembershipId",
                table: "AdUserAccounts",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMemberships_StructureId",
                table: "OrgMemberships",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgSections_CostCenterId",
                table: "OrgSections",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgSections_DirectionId",
                table: "OrgSections",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgStructures_MailDatabaseGroupId",
                table: "OrgStructures",
                column: "MailDatabaseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgStructures_SectionId",
                table: "OrgStructures",
                column: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdUserAccountProvisions");

            migrationBuilder.DropTable(
                name: "AdUserAccounts");

            migrationBuilder.DropTable(
                name: "OrgLocations");

            migrationBuilder.DropTable(
                name: "OrgMemberships");

            migrationBuilder.DropTable(
                name: "OrgStructures");

            migrationBuilder.DropTable(
                name: "OrgMailDatabaseGroups");

            migrationBuilder.DropTable(
                name: "OrgSections");

            migrationBuilder.DropTable(
                name: "OrgCostCenters");

            migrationBuilder.DropTable(
                name: "OrgDirections");
        }
    }
}
