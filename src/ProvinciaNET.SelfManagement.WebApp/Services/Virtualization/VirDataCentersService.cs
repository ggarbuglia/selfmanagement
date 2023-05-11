using Microsoft.AspNetCore.Components;
using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;

namespace ProvinciaNET.SelfManagement.WebApp.Services.Virtualization
{
    /// <summary>
    /// VirDataCenter Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApp.Services.WebApiServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirDataCenter&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApp.Services.IWebApiServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirDataCenter&gt;" />
    public partial class VirDataCenterService : WebApiServiceBase<VirDataCenter>, IWebApiServiceBase<VirDataCenter>
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirDataCenterService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="navigationManager">The navigation manager.</param>
        public VirDataCenterService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
            : base(httpClientFactory, navigationManager)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
            _navigationManager = navigationManager;
        }
    }
}
