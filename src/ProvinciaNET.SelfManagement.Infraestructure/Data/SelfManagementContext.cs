using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProvinciaNET.SelfManagement.Core.Entities;

namespace ProvinciaNET.SelfManagement.Infraestructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<SelfManagementContext>
    {
        public ApplicationDbContextFactory()
        {
        }

        public SelfManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SelfManagementContext>();
            optionsBuilder.UseSqlServer(AppConfiguration.GetConnectionString("SelfManagement"));

            return new SelfManagementContext(optionsBuilder.Options);
        }
    }

    public class SelfManagementContext : DbContext
    {
        public SelfManagementContext(DbContextOptions<SelfManagementContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfiguration.GetConnectionString("SelfManagement"));
        }

        public DbSet<AdUserAccount> AdUserAccounts { get; set; }
        public DbSet<AdUserAccountProvision> AdUserAccountProvisions { get; set; }
        public DbSet<OrgMembership> OrgMemberships { get; set; }
        public DbSet<OrgStructure> OrgStructures { get; set; }
        public DbSet<OrgSection> OrgSections { get; set; }
        public DbSet<OrgDirection> OrgDirections { get; set; }
        public DbSet<OrgMailDatabaseGroup> OrgMailDatabaseGroups { get; set; }
        public DbSet<OrgLocation> OrgLocations { get; set; }
        public DbSet<OrgCostCenter> OrgCostCenters { get; set; }
    }
}