using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvinciaNET.SelfManagement.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData_OrgMailDatabaseGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var table = "OrgMailDatabaseGroups";
            var username = "System";
            var now = DateTime.Now;

            var columns = new[] {
                "Name",
                "Active",
                "CreatedBy",
                "CreatedOn",
                "ModifiedBy",
                "ModifiedOn"
            };

            var data = new[] {
                "Agencias",
                "Cajeros",
                "Centro de Contactos",
                "Servicios",
                "Usuarios"
            };

            foreach (var item in data)
            {
                migrationBuilder.InsertData(
                    schema: "dbo", 
                    table: table, 
                    columns: columns, 
                    values: new object[] { item, true, username, now, null, null }
                    );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
