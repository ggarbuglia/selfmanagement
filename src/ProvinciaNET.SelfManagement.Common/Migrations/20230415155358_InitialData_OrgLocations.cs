using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvinciaNET.SelfManagement.Common.Migrations
{
    /// <inheritdoc />
    public partial class InitialData_OrgLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var table = "OrgLocations";
            var username = "System";
            var now = DateTime.Now;

            var columns = new[] {
                "Name",
                "Address",
                "PostalCode",
                "City",
                "AdGroupAccountName",
                "AdGroupDisplayName",
                "Active",
                "CreatedBy",
                "CreatedOn",
                "ModifiedBy",
                "ModifiedOn"
            };

            var data = new object[] {
                new [] { "Edificio Mitre", "Reconquista 46 Piso 6", "C1003ABB", "Cdad Autónoma de Buenos Aires", "site-mit", "Edificio Mitre" },
                new [] { "Edificio Calderón", "Calderón de la Barca 1462", "C1407KQD", "Cdad Autónoma de Buenos Aires", "site-cal", "Edificio Calderón" },
                new [] { "Edificio Caseros", "Av. Caseros 3039 Piso 1", "C1264AAK", "Cdad Autónoma de Buenos Aires", "site-pol", "Edificio Caseros" },
                new [] { "= Cajeros =", "", "", "", "Pnet - Cajeros", "Pnet - Cajeros" }
            };

            foreach (var item in data.Cast<string[]>())
            {
                var nm = item[0]; // Name
                var ad = item[1]; // Address
                var pc = item[2]; // PostalCode
                var ct = item[3]; // City
                var ac = item[4]; // AdGroupAccountName
                var dn = item[5]; // AdGroupDisplayName

                migrationBuilder.InsertData(table, columns, new object[] { nm, ad, pc, ct, ac, dn, true, username, now, null, null });
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
