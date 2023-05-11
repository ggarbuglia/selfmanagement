using Microsoft.AspNetCore.Components;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;

namespace ProvinciaNET.SelfManagement.WebApp.Services.Organization
{
    /// <summary>
    /// OrgMembership Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApp.Services.WebApiServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgMembership&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApp.Services.IWebApiServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgMembership&gt;" />
    public partial class OrgMembershipService : WebApiServiceBase<OrgMembership>, IWebApiServiceBase<OrgMembership>
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgMembershipService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="navigationManager">The navigation manager.</param>
        public OrgMembershipService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
            : base(httpClientFactory, navigationManager)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
            _navigationManager = navigationManager;
        }
    }
}
