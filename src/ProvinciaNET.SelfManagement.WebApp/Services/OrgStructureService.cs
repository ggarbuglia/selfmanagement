using Microsoft.AspNetCore.Components;
using ProvinciaNET.SelfManagement.Core.Entities;
using Radzen;
using System.Text;
using System.Text.Encodings.Web;
using static System.Net.Mime.MediaTypeNames;

namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    /// <summary>
    /// OrgStructure Service
    /// </summary>
    public partial class OrgStructureService : IOrgStructureService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgStructureService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="navigationManager">The navigation manager.</param>
        public OrgStructureService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
            _navigationManager = navigationManager;
        }

        /// <summary>
        /// Gets all OrgStructures with the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="top">The top.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="orderby">The orderby.</param>
        /// <param name="expand">The expand.</param>
        /// <param name="select">The select.</param>
        /// <param name="count">The count.</param>
        /// <returns>A collection of <see cref="OrgStructure"/></returns>
        public async Task<ODataServiceResult<OrgStructure>> GetOdataAsync(string? filter = default, int? top = default, int? skip = default, string? orderby = default, string? expand = default, string? select = default, bool? count = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}odata/OrgStructures");
            uri = uri.GetODataUri(filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<ODataServiceResult<OrgStructure>>();
        }

        /// <summary>
        /// Gets all OrgStructures.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OrgStructure>> GetAsync()
        {
            var response = await _httpClient.GetAsync($"/api/OrgStructures");
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<IEnumerable<OrgStructure>>();
        }

        /// <summary>
        /// Gets a OrgStructure with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An instance of <see cref="OrgStructure"/></returns>
        public async Task<OrgStructure> GetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/OrgStructures/{id}");
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<OrgStructure>();
        }

        /// <summary>
        /// Creates a OrgStructure resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>An instance of <see cref="OrgStructure"/></returns>
        public async Task<OrgStructure> CreateAsync(OrgStructure resource)
        {
            var payload = new StringContent(ODataJsonSerializer.Serialize(resource), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PostAsync("/api/OrgStructures", payload);
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<OrgStructure>();
        }

        /// <summary>
        /// Updates a OrgStructure resource.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        public async Task UpdateAsync(int id, OrgStructure resource)
        {
            var payload = new StringContent(ODataJsonSerializer.Serialize(resource), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PutAsync($"/api/OrgStructures/{id}", payload);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Deletes a OrgStructure resource.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/OrgStructures/{id}");
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
            _navigationManager.NavigateTo($"/export/OrgStructures/{fileType}(fileName='{filename}')", true);
        }
    }
}