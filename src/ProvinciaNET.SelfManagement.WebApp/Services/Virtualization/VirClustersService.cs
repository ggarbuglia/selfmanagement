﻿using Microsoft.AspNetCore.Components;
using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;

namespace ProvinciaNET.SelfManagement.WebApp.Services.Virtualization
{
    /// <summary>
    /// VirCluster Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApp.Services.WebApiServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirCluster&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApp.Services.IWebApiServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirCluster&gt;" />
    public partial class VirClusterService : WebApiServiceBase<VirCluster>, IWebApiServiceBase<VirCluster>
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirClusterService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="navigationManager">The navigation manager.</param>
        public VirClusterService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
            : base(httpClientFactory, navigationManager)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
            _navigationManager = navigationManager;
        }
    }
}