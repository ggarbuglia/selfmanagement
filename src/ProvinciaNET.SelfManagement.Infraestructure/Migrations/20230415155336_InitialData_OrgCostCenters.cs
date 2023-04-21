using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvinciaNET.SelfManagement.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData_OrgCostCenters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var table = "OrgCostCenters";
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
                "AR - ADMINISTRACION DE RED",
                "BS - GESTION de BS y SERVICIOS",
                "CC - CENTRO DE CONTACTOS",
                "GA - ADMINISTRACION",
                "GC - GERENCIA COMERCIAL",
                "GF - FINANZAS",
                "GG - GCIA GRAL y DIRECTORIO",
                "GI - INFRAESTRUCTURA",
                "GL - LEGALES",
                "GO - OPERACIONES",
                "GP - PROYECTOS y DESARROLLO",
                "MK - DIRECCION de COMUNICACION",
                "RH - GESTION DE PERSONAS",
                "SR - CAJAS"
            };

            foreach (var item in data)
            {
                migrationBuilder.InsertData(table, columns, new object[] { item, true, username, now, null, null });
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
