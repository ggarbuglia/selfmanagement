using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvinciaNET.SelfManagement.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData_OrgDirections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var table = "OrgDirections";
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
                "Dirección Comercial y de Comunicaciones",
                "Dirección de Administración y Finanzas",
                "Dirección de Recaudación y Medios de Pago",
                "Dirección de Tecnología",
                "Presidencia"
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
