using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;

namespace ProvinciaNET.SelfManagement.WebApi.Helpers
{
    /// <summary>
    /// OData Helper class
    /// </summary>
    public class ODataHelper
    {
        /// <summary>
        /// Gets the EDM model.
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

            return builder.GetEdmModel();
        }
    }
}