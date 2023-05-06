using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvinciaNET.SelfManagement.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "OrgCostCenters",
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "OrgCostCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgSections_OrgDirections_DirectionId",
                        column: x => x.DirectionId,
                        principalSchema: "dbo",
                        principalTable: "OrgDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgStructures",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "OrgMailDatabaseGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgStructures_OrgSections_SectionId",
                        column: x => x.SectionId,
                        principalSchema: "dbo",
                        principalTable: "OrgSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgMemberships",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "OrgStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdUserAccounts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SamAccountName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UserPrincipalName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
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
                        principalSchema: "dbo",
                        principalTable: "OrgLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdUserAccounts_OrgMemberships_MembershipId",
                        column: x => x.MembershipId,
                        principalSchema: "dbo",
                        principalTable: "OrgMemberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdUserAccountProvisions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(100)", nullable: false),
                    HasError = table.Column<bool>(type: "bit", nullable: false),
                    Error = table.Column<string>(type: "varchar(max)", nullable: false),
                    AdUserAccountId = table.Column<int>(type: "int", nullable: false),
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
                        principalSchema: "dbo",
                        principalTable: "AdUserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdUserAccountProvisions_AdUserAccountId",
                schema: "dbo",
                table: "AdUserAccountProvisions",
                column: "AdUserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AdUserAccounts_LocationId",
                schema: "dbo",
                table: "AdUserAccounts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdUserAccounts_MembershipId",
                schema: "dbo",
                table: "AdUserAccounts",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMemberships_StructureId",
                schema: "dbo",
                table: "OrgMemberships",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgSections_CostCenterId",
                schema: "dbo",
                table: "OrgSections",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgSections_DirectionId",
                schema: "dbo",
                table: "OrgSections",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgStructures_MailDatabaseGroupId",
                schema: "dbo",
                table: "OrgStructures",
                column: "MailDatabaseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgStructures_SectionId",
                schema: "dbo",
                table: "OrgStructures",
                column: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdUserAccountProvisions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdUserAccounts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrgLocations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrgMemberships",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrgStructures",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrgMailDatabaseGroups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrgSections",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrgCostCenters",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrgDirections",
                schema: "dbo");
        }
    }
}