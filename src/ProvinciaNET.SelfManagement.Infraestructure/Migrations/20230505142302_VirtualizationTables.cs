using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvinciaNET.SelfManagement.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class VirtualizationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VirDataCenters",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirDataCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VirNetworks",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Mask = table.Column<int>(type: "int", nullable: false),
                    Gateway = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirNetworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VirOperatingSystemTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatingSystem = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Flavor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirOperatingSystemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VirResources",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VirClusters",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DataCenterId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirClusters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirClusters_VirDataCenters_DataCenterId",
                        column: x => x.DataCenterId,
                        principalSchema: "dbo",
                        principalTable: "VirDataCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VirDataStores",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ClusterId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirDataStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirDataStores_VirClusters_ClusterId",
                        column: x => x.ClusterId,
                        principalSchema: "dbo",
                        principalTable: "VirClusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VirtualMachines",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    FolderPath = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Memory = table.Column<int>(type: "int", nullable: false),
                    UseTemplate = table.Column<bool>(type: "bit", nullable: false),
                    Template = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UseImage = table.Column<bool>(type: "bit", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    UseDhcp = table.Column<bool>(type: "bit", nullable: false),
                    IPv4Address = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    DnsAddress1 = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    DnsAddress2 = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    DataStoreId = table.Column<int>(type: "int", nullable: false),
                    NetworkId = table.Column<int>(type: "int", nullable: false),
                    OperatingSystemTypeId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualMachines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualMachines_VirDataStores_DataStoreId",
                        column: x => x.DataStoreId,
                        principalSchema: "dbo",
                        principalTable: "VirDataStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VirtualMachines_VirNetworks_NetworkId",
                        column: x => x.NetworkId,
                        principalSchema: "dbo",
                        principalTable: "VirNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VirtualMachines_VirOperatingSystemTypes_OperatingSystemTypeId",
                        column: x => x.OperatingSystemTypeId,
                        principalSchema: "dbo",
                        principalTable: "VirOperatingSystemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VirCategoryTags",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Tag = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    VirtualMachineId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirCategoryTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirCategoryTags_VirtualMachines_VirtualMachineId",
                        column: x => x.VirtualMachineId,
                        principalSchema: "dbo",
                        principalTable: "VirtualMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VirtualMachineDisks",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    DiskType = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    DiskSizeGB = table.Column<int>(type: "int", nullable: false),
                    VirtualMachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualMachineDisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualMachineDisks_VirtualMachines_VirtualMachineId",
                        column: x => x.VirtualMachineId,
                        principalSchema: "dbo",
                        principalTable: "VirtualMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VirCategoryTags_VirtualMachineId",
                schema: "dbo",
                table: "VirCategoryTags",
                column: "VirtualMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_VirClusters_DataCenterId",
                schema: "dbo",
                table: "VirClusters",
                column: "DataCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_VirDataStores_ClusterId",
                schema: "dbo",
                table: "VirDataStores",
                column: "ClusterId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualMachineDisks_VirtualMachineId",
                schema: "dbo",
                table: "VirtualMachineDisks",
                column: "VirtualMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualMachines_DataStoreId",
                schema: "dbo",
                table: "VirtualMachines",
                column: "DataStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualMachines_NetworkId",
                schema: "dbo",
                table: "VirtualMachines",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualMachines_OperatingSystemTypeId",
                schema: "dbo",
                table: "VirtualMachines",
                column: "OperatingSystemTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VirCategoryTags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VirResources",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VirtualMachineDisks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VirtualMachines",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VirDataStores",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VirNetworks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VirOperatingSystemTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VirClusters",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VirDataCenters",
                schema: "dbo");
        }
    }
}