using Microsoft.AspNetCore.Components;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;

namespace ProvinciaNET.SelfManagement.WebApp.Services.Organization
{
    /// <summary>
    /// OrgSection Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApp.Services.WebApiServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgSection&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApp.Services.IWebApiServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgSection&gt;" />
    public partial class OrgSectionService : WebApiServiceBase<OrgSection>, IWebApiServiceBase<OrgSection>
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgSectionService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="navigationManager">The navigation manager.</param>
        public OrgSectionService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
            : base(httpClientFactory, navigationManager)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
            _navigationManager = navigationManager;
        }
    }
}
