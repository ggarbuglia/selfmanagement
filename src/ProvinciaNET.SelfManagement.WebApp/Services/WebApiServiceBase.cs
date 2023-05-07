using Microsoft.AspNetCore.Components;
using Radzen;
using System.Text;
using System.Text.Encodings.Web;
using static System.Net.Mime.MediaTypeNames;

namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    /// <summary>
    /// WebApi Service Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class WebApiServiceBase<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly string _typeName;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiServiceBase{T}"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="navigationManager">The navigation manager.</param>
        public WebApiServiceBase(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
            _navigationManager = navigationManager;
            _typeName = typeof(T).Name;
        }

        /// <summary>
        /// Gets all resources with the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="top">The top.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="orderby">The orderby.</param>
        /// <param name="expand">The expand.</param>
        /// <param name="select">The select.</param>
        /// <param name="count">The count.</param>
        /// <returns>A collection of <see typeparamref="T"/></returns>
        public async Task<ODataServiceResult<T>> GetOdataAsync(string? filter = default, int? top = default, int? skip = default, string? orderby = default, string? expand = default, string? select = default, bool? count = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}odata/{_typeName}s");
            uri = uri.GetODataUri(filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<ODataServiceResult<T>>();
        }

        /// <summary>
        /// Gets all Tresources.
        /// </summary>
        /// <returns>A collection of <see typeparamref="T"/></returns>
        public async Task<IEnumerable<T>> GetAsync()
        {
            var response = await _httpClient.GetAsync($"/api/{_typeName}s");
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<IEnumerable<T>>();
        }

        /// <summary>
        /// Gets a resource with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An instance of <see typeparamref="T"/></returns>
        public async Task<T> GetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/{_typeName}s/{id}");
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<T>();
        }

        /// <summary>
        /// Creates a resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>An instance of <see typeparamref="T"/></returns>
        public async Task<T> CreateAsync(T resource)
        {
            var payload = new StringContent(ODataJsonSerializer.Serialize(resource), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PostAsync($"/api/{_typeName}s", payload);
            response.EnsureSuccessStatusCode();
            return await response.ReadAsync<T>();
        }

        /// <summary>
        /// Updates a resource.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        public async Task UpdateAsync(int id, T resource)
        {
            var payload = new StringContent(ODataJsonSerializer.Serialize(resource), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PutAsync($"/api/{_typeName}s/{id}", payload);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Deletes a resource.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/{_typeName}s/{id}");
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Exports data to file.
        /// </summary>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="filename">The filename.</param>
        public void ExportToFile(string fileType, string filename)
        {
            filename = !string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export";
            _navigationManager.NavigateTo($"/export/{_typeName}s/{fileType}(fileName='{filename}')", true);
        }
    }
}