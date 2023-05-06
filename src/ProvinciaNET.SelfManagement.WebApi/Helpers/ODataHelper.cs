using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;

namespace ProvinciaNET.SelfManagement.WebApi.Helpers
{
    /// <summary>
    /// OData Helper class
    /// </summary>
    public class ODataHelper
    {
        /// <summary>
        /// Gets all 'EDM model.
        /// </summary>
        /// <returns></returns>
        public static IEdmModel GetModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<AdUserAccount>("AdUserAccounts");
            builder.EntitySet<AdUserAccountProvision>("AdUserAccountProvisions");
            builder.EntitySet<OrgCostCenter>("OrgCostCenters");
            builder.EntitySet<OrgDirection>("OrgDirections");
            builder.EntitySet<OrgLocation>("OrgLocations");
            builder.EntitySet<OrgMailDatabaseGroup>("OrgMailDatabaseGroups");
            builder.EntitySet<OrgMembership>("OrgMemberships");
            builder.EntitySet<OrgSection>("OrgSections");
            builder.EntitySet<OrgStructure>("OrgStructures");

            builder.EntitySet<VirCategoryTag>("VirCategoryTags");
            builder.EntitySet<VirCluster>("VirClusters");
            builder.EntitySet<VirDataCenter>("VirDataCenters");
            builder.EntitySet<VirDataStore>("VirDataStores");
            builder.EntitySet<VirNetwork>("VirNetworks");
            builder.EntitySet<VirOperatingSystemType>("VirOperatingSystemTypes");
            builder.EntitySet<VirResource>("VirResources");
            builder.EntitySet<VirtualMachine>("VirtualMachines");

            return builder.GetEdmModel();
        }
    }
}