using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvinciaNET.SelfManagement.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData_OrgSections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var table = "OrgSections";
            var username = "System";
            var now = DateTime.Now;

            var columns = new[] {
                "Name",
                "CostCenterId",
                "DirectionId",
                "Active",
                "CreatedBy",
                "CreatedOn",
                "ModifiedBy",
                "ModifiedOn"
            };

            var data = new Tuple<string, int, int>[] {
                new("Área de Comunicación", 1, 12),
                new("Área de Marketing", 1, 12),
                new("Área de RSE", 1, 12),
                new("Gerencia de Administración", 2, 4),
                new("Gerencia de Finanzas", 2, 6),
                new("Gerencia de Legales", 2, 9),
                new("Gestión de Bienes", 2, 2),
                new("Secretaría", 2, 4),
                new("Gerencia de Operaciones", 3, 10),
                new("Seguimiento de Gestión", 3, 7),
                new("Área de Administración de Red de Agencias", 3, 1),
                new("Área de Desarrollo de Negocios de Recaudación", 3, 7),
                new("Gerencia de Centro de Contactos", 4, 3),
                new("Gerencia de Infraestructura", 4, 8),
                new("Gerencia de Proyectos y Desarrollo", 4, 11),
                new("COE Agile", 4, 11),
                new("Área de Desarrollo de Negocios de Tecnología", 4, 7),
                new("Seguridad Informática", 4, 8),
                new("Gerencia Comercial", 5, 5),
                new("Gerencia de Gestión de Personas", 5, 13),
                new("Gerencia de E-Commerce", 5, 7)
            };

            foreach (var t in data)
            {
                migrationBuilder.InsertData(
                    schema: "dbo",
                    table: table,
                    columns: columns,
                    values: new object[] { t.Item1, t.Item3, t.Item2, true, username, now, null, null }
                    );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}