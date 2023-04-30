using Microsoft.AspNetCore.Components;
using ProvinciaNET.SelfManagement.Core.Entities;
using Radzen;
using System.Text;
using System.Text.Encodings.Web;
using static System.Net.Mime.MediaTypeNames;

namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    /// <summary>
    /// OrgDirection Service
    /// </summary>
    public partial class OrgDirectionService : IOrgDirectionService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgDirectionService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="navigationManager">The navigation manager.</param>
        public OrgDirectionService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
            _navigationManager = navigationManager;
        }

        /// <summary>
        /// Gets all OrgDirections with the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="top">The top.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="orderby">The orderby.</param>
        /// <param name="expand">The expand.</param>
        /// <param name="select">The select.</param>
        /// <param name="count">The count.</param>
        /// <returns>A collection of <see cref="OrgDirection"/></returns>
        public async Task<ODataServiceResult<OrgDirection>> GetOdataAsync(string? filter = default, int? top = default, int? skip = default, string? orderby = default, string? expand = default, string? select = default, bool? count = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}odata/OrgDirections");
            uri = uri.GetODataUri(filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<ODataServiceResult<OrgDirection>>();
        }

        /// <summary>
        /// Gets all OrgDirections.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OrgDirection>> GetAsync()
        {
            var response = await _httpClient.GetAsync($"/api/OrgDirections");
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<IEnumerable<OrgDirection>>();
        }

        /// <summary>
        /// Gets a OrgDirection with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An instance of <see cref="OrgDirection"/></returns>
        public async Task<OrgDirection> GetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/OrgDirections/{id}");
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<OrgDirection>();
        }

        /// <summary>
        /// Creates a OrgDirection resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>An instance of <see cref="OrgDirection"/></returns>
        public async Task<OrgDirection> CreateAsync(OrgDirection resource)
        {
            var payload = new StringContent(ODataJsonSerializer.Serialize(resource), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PostAsync("/api/OrgDirections", payload);
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<OrgDirection>();
        }

        /// <summary>
        /// Updates a OrgDirection resource.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        public async Task UpdateAsync(int id, OrgDirection resource)
        {
            var payload = new StringContent(ODataJsonSerializer.Serialize(resource), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PutAsync($"/api/OrgDirections/{id}", payload);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Deletes a OrgDirection resource.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/OrgDirections/{id}");
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Exports data to file.
        /// </summary>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="filename">The filename.</param>
        public void ExportToFile(string fileType, string filename)
        {
            filename = (!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export");
            _navigationManager.NavigateTo($"/export/OrgDirections/{fileType}(fileName='{filename}')", true);
        }
    }
}