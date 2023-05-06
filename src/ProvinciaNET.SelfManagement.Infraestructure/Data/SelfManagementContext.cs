using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;

namespace ProvinciaNET.SelfManagement.Infraestructure.Data
{
    /// <summary>
    /// SelfManagementContext Class
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public partial class SelfManagementContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelfManagementContext"/> class.
        /// </summary>
        /// <remarks>
        /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        /// for more information and examples.
        /// </remarks>
        public SelfManagementContext()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelfManagementContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SelfManagementContext(DbContextOptions<SelfManagementContext> options) : base(options) { }

        /// <summary>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        /// <remarks>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        /// for more information and examples.
        /// </para>
        /// </remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfiguration.GetConnectionString("DefaultConnection"));
        }

        #region Organization Entities

        /// <summary>
        /// Gets or sets the ad user account provisions.
        /// </summary>
        /// <value>
        /// The ad user account provisions.
        /// </value>
        public DbSet<AdUserAccountProvision> AdUserAccountProvisions { get; set; }

        /// <summary>
        /// Gets or sets the ad user accounts.
        /// </summary>
        /// <value>
        /// The ad user accounts.
        /// </value>
        public DbSet<AdUserAccount> AdUserAccounts { get; set; }

        /// <summary>
        /// Gets or sets the org cost centers.
        /// </summary>
        /// <value>
        /// The org cost centers.
        /// </value>
        public DbSet<OrgCostCenter> OrgCostCenters { get; set; }

        /// <summary>
        /// Gets or sets the org directions.
        /// </summary>
        /// <value>
        /// The org directions.
        /// </value>
        public DbSet<OrgDirection> OrgDirections { get; set; }

        /// <summary>
        /// Gets or sets the org locations.
        /// </summary>
        /// <value>
        /// The org locations.
        /// </value>
        public DbSet<OrgLocation> OrgLocations { get; set; }

        /// <summary>
        /// Gets or sets the org mail database groups.
        /// </summary>
        /// <value>
        /// The org mail database groups.
        /// </value>
        public DbSet<OrgMailDatabaseGroup> OrgMailDatabaseGroups { get; set; }

        /// <summary>
        /// Gets or sets the org memberships.
        /// </summary>
        /// <value>
        /// The org memberships.
        /// </value>
        public DbSet<OrgMembership> OrgMemberships { get; set; }

        /// <summary>
        /// Gets or sets the org sections.
        /// </summary>
        /// <value>
        /// The org sections.
        /// </value>
        public DbSet<OrgSection> OrgSections { get; set; }

        /// <summary>
        /// Gets or sets the org structures.
        /// </summary>
        /// <value>
        /// The org structures.
        /// </value>
        public DbSet<OrgStructure> OrgStructures { get; set; }

        #endregion Organization Entities

        #region Virtualization Entities

        /// <summary>
        /// Gets or sets the vir resources.
        /// </summary>
        /// <value>
        /// The vir resources.
        /// </value>
        public DbSet<VirResource> VirResources { get; set; }

        /// <summary>
        /// Gets or sets the vir data centers.
        /// </summary>
        /// <value>
        /// The vir data centers.
        /// </value>
        public DbSet<VirDataCenter> VirDataCenters { get; set; }

        /// <summary>
        /// Gets or sets the vir clusters.
        /// </summary>
        /// <value>
        /// The vir clusters.
        /// </value>
        public DbSet<VirCluster> VirClusters { get; set; }

        /// <summary>
        /// Gets or sets the vir data stores.
        /// </summary>
        /// <value>
        /// The vir data stores.
        /// </value>
        public DbSet<VirDataStore> VirDataStores { get; set; }

        /// <summary>
        /// Gets or sets the vir networks.
        /// </summary>
        /// <value>
        /// The vir networks.
        /// </value>
        public DbSet<VirNetwork> VirNetworks { get; set; }

        /// <summary>
        /// Gets or sets the vir operating system types.
        /// </summary>
        /// <value>
        /// The vir operating system types.
        /// </value>
        public DbSet<VirOperatingSystemType> VirOperatingSystemTypes { get; set; }

        /// <summary>
        /// Gets or sets the virtual machines.
        /// </summary>
        /// <value>
        /// The virtual machines.
        /// </value>
        public DbSet<VirtualMachine> VirtualMachines { get; set; }

        /// <summary>
        /// Gets or sets the virtual machine disks.
        /// </summary>
        /// <value>
        /// The virtual machine disks.
        /// </value>
        public DbSet<VirtualMachineDisk> VirtualMachineDisks { get; set; }

        /// <summary>
        /// Gets or sets the vir category tags.
        /// </summary>
        /// <value>
        /// The vir category tags.
        /// </value>
        public DbSet<VirCategoryTag> VirCategoryTags { get; set; }

        #endregion Virtualization Entities
    }
}