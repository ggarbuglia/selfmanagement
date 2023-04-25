using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities;

namespace ProvinciaNET.SelfManagement.Infraestructure.Data
{
    public partial class SelfManagementContext : DbContext
    {
        public SelfManagementContext() { }

        public SelfManagementContext(DbContextOptions<SelfManagementContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfiguration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<AdUserAccountProvision> AdUserAccountProvisions { get; set; }

        public DbSet<AdUserAccount> AdUserAccounts { get; set; }

        public DbSet<OrgCostCenter> OrgCostCenters { get; set; }

        public DbSet<OrgDirection> OrgDirections { get; set; }

        public DbSet<OrgLocation> OrgLocations { get; set; }

        public DbSet<OrgMailDatabaseGroup> OrgMailDatabaseGroups { get; set; }

        public DbSet<OrgMembership> OrgMemberships { get; set; }

        public DbSet<OrgSection> OrgSections { get; set; }

        public DbSet<OrgStructure> OrgStructures { get; set; }
    }
}