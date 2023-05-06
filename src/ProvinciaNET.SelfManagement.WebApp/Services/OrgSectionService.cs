using Microsoft.AspNetCore.Components;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using Radzen;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    /// <summary>
    /// OrgSection Service
    /// </summary>
    public partial class OrgSectionService : IOrgSectionService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgSectionService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="navigationManager">The navigation manager.</param>
        public OrgSectionService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
            _navigationManager = navigationManager;
        }

        /// <summary>
        /// Gets all OrgSections with the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="top">The top.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="orderby">The orderby.</param>
        /// <param name="expand">The expand.</param>
        /// <param name="select">The select.</param>
        /// <param name="count">The count.</param>
        /// <returns>A collection of <see cref="OrgSection"/></returns>
        public async Task<ODataServiceResult<OrgSection>> GetOdataAsync(string? filter = default, int? top = default, int? skip = default, string? orderby = default, string? expand = default, string? select = default, bool? count = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}odata/OrgSections");
            uri = uri.GetODataUri(filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<ODataServiceResult<OrgSection>>();
        }

        /// <summary>
        /// Gets all OrgSections.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OrgSection>> GetAsync()
        {
            var response = await _httpClient.GetAsync($"/api/OrgSections");
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<IEnumerable<OrgSection>>();
        }

        /// <summary>
        /// Gets a OrgSection with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An instance of <see cref="OrgSection"/></returns>
        public async Task<OrgSection> GetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/OrgSections/{id}");
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<OrgSection>();
        }

        /// <summary>
        /// Creates a OrgSection resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>An instance of <see cref="OrgSection"/></returns>
        public async Task<OrgSection> CreateAsync(OrgSection resource)
        {
            var payload = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, Application.Json);
            var response = _httpClient.PostAsync("/api/OrgSections", payload).Result;
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<OrgSection>();
        }

        /// <summary>
        /// Updates a OrgSection resource.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        public async Task UpdateAsync(int id, OrgSection resource)
        {
            var payload = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PutAsync($"/api/OrgSections/{id}", payload);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Deletes a OrgSection resource.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/OrgSections/{id}");
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
            _navigationManager.NavigateTo($"/export/OrgSections/{fileType}(fileName='{filename}')", true);
        }
    }
}