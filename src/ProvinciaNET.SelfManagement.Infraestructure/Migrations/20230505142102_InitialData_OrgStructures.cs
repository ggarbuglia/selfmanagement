using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvinciaNET.SelfManagement.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData_OrgStructures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var table = "OrgStructures";
            var username = "System";
            var now = DateTime.Now;

            var columns = new[] {
                "Group",
                "OrgUnit",
                "MailDatabaseGroupId",
                "SectionId",
                "Active",
                "CreatedBy",
                "CreatedOn",
                "ModifiedBy",
                "ModifiedOn"
            };

            var data = new Tuple<string, string, int, int>[] {
                new("[General]", "OU=Adm de Red,OU=Dir. Recaudacion y M. de Pago,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 1, 11),
                new("Red Propia", "OU=Red Propia,OU=Tesoreria,OU=Gcia. Operaciones,OU=Dir. Recaudacion y M. de Pago,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 1, 11),
                new("Supervisores de Caja", "OU=Supervisores,OU=Tesoreria,OU=Gcia. Operaciones,OU=Dir. Recaudacion y M. de Pago,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 2, 11),
                new("Cajeros Principales", "OU=Cajeros Principales,OU=Tesoreria,OU=Gcia. Operaciones,OU=Dir. Recaudacion y M. de Pago,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 2, 11),
                new("Cajeros", "OU=Cajeros,OU=Sucursales Propias,OU=Gcia. Operaciones,OU=Dir. Recaudacion y M. de Pago,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 2, 11),

                new("[General]", "OU=Comunicacion,OU=Dir. Comercial y Comunicacion,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 1),
                new("[General]", "OU=DN Recaudacion,OU=Dir. Recaudacion y M. de Pago,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 12),
                new("[General]", "OU=Marketing,OU=Dir. Comercial y Comunicacion,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 2),
                new("[General]", "OU=RSE,OU=Dir. Comercial y Comunicacion,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 3),
                new("[General]", "OU=PMO,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 16),
                new("[General]", "OU=Gcia. Comercial,OU=Gerencia General,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 19),

                new("[General]", "OU=Gcia. Administracion,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 4),
                new("Administración de Personal", "OU=Adm de Personal,OU=Gcia. Administracion,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 4),
                new("Compras", "OU=Compras,OU=Gcia. Administracion,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 4),
                new("Contabilidad", "OU=Contabilidad,OU=Gcia. Administracion,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 4),
                new("Control de Gestión", "OU=Control de Gestion,OU=Gcia. Administracion,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 4),
                new("Impuestos", "OU=Impuestos,OU=Gcia. Administracion,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 4),

                new("[General]", "OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Banco Provincia", "OU=Banco Provincia,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("IOMA", "OU=IOMA,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("MultiProducto", "OU=MultiProducto,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Provincia ART", "OU=Provincia ART,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Provincia Leasing", "OU=Provincia Leasing,OU=CC - Operadores,OU=Centro de Contactos,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Provincia Microempresas", "OU=Provincia Microempresas,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Provincia NET", "OU=Provincia NET,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Provincia Seguros", "OU=Provincia Seguros,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("VDT", "OU=VDT,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Venta Catalogo", "OU=Venta Catalogo,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Linea 144", "OU=144,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Mejora Continua", "OU=Mejora Continua,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Provincia Vida", "OU=Provincia Vida,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),
                new("Marketplace", "OU=Marketplace,OU=Operadores,OU=Gcia. Centro de Contacto,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 3, 13),

                new("[General]", "OU=Gcia. E-Commerce,OU=Gerencia General,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 21),
                new("[General]", "OU=Gcia. Finanzas,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 5),
                new("[General]", "OU=Gcia. Gestion Personas,OU=Gerencia General,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 20),
                new("[General]", "OU=Gcia. Legales,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 6),
                new("[General]", "OU=Gcia. Operaciones,OU=Dir. Recaudacion y M. de Pago,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 9),
                new("[General]", "OU=Gestion Bienes,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 7),
                new("[General]", "OU=Secretaria,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 8),
                new("[General]", "OU=Seguimiento Gestion,OU=Dir. Adm y Finanzas,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 10),
                new("[General]", "OU=Seguridad Informatica,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 18),

                new("[General]", "OU=Gcia. Infraestructura,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 14),
                new("Infraestructura", "OU=Infraestructura,OU=Gcia. Infraestructura,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 14),
                new("Gestión de Servicio", "OU=Gestion de Servicio,OU=Gcia. Infraestructura,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 14),

                new("[General]", "OU=Gcia. Proyectos y Desarrollo,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 15),
                new("Análisis Funcional", "OU=Analisis,OU=Gcia. Proyectos y Desarrollo,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 15),
                new("Desarrollo", "OU=Desarrollo,OU=Gcia. Proyectos y Desarrollo,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 15),
                new("Proyectos", "OU=Proyectos,OU=Gcia. Proyectos y Desarrollo,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 15),
                new("Testing", "OU=Testing,OU=Gcia. Proyectos y Desarrollo,OU=Dir. Tecnologia,OU=Empleados,OU=Usuarios,OU=Bapro Pagos,DC=g-bapro,DC=net", 5, 15),
            };

            foreach (var t in data)
            {
                migrationBuilder.InsertData(
                    schema: "dbo",
                    table: table,
                    columns: columns,
                    values: new object[] { t.Item1, t.Item2, t.Item3, t.Item4, true, username, now, null, null }
                    );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}