using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvinciaNET.SelfManagement.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData_VirResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var table = "VirResources";
            var username = "System";
            var now = DateTime.Now;

            var columns = new[] {
                "Group",
                "Name",
                "Value",
                "Active",
                "CreatedBy",
                "CreatedOn",
                "ModifiedBy",
                "ModifiedOn"
            };

            var data = new Tuple<string, string, string>[] {
                new("OperatingSystem", "Windows", "Windows"),
                new("OperatingSystem", "Linux", "Windows"),
                new("DiskType", "SAS", "SAS"),
                new("DiskType", "SSD", "SSD"),
                new("Cores", "2 Cores", "2"),
                new("Cores", "4 Cores", "4"),
                new("Cores", "8 Cores", "8"),
                new("Memory", "2 GB", "2"),
                new("Memory", "4 GB", "4"),
                new("Memory", "8 GB", "8"),
                new("Memory", "12 GB", "12"),
                new("Memory", "16 GB", "16"),
            };

            foreach (var t in data)
            {
                migrationBuilder.InsertData(
                    schema: "dbo", 
                    table: table, 
                    columns: columns, 
                    values: new object[] { t.Item1, t.Item2, t.Item3, true, username, now, null, null }
                    );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
