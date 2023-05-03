using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities;

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
        public SelfManagementContext() { }

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
    }
}